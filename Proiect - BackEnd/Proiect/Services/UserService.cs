using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Proiect.Model.Constants;
using Proiect.Model.Entities;
using Proiect.Model.Entities.DTOs;
using Proiect.Repositories.RepositoryWrapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<StandardUser> _userManager;
        private readonly IRepositoryWrapper _repository;

        public UserService(
            UserManager<StandardUser> userManager,
            IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new StandardUser();
            
            registerUser.Email = dto.Email;
            registerUser.UserName = dto.Email;
            registerUser.FirstName = dto.FirstName;
            registerUser.LastName = dto.LastName;

            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(registerUser, UserRoleTypes.StandardUser);

                return true;
            }

            else
            {
                var message = string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description));
                throw new Exception(message);
            }
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            StandardUser user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                user = await _repository.StandardUser.GetByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4k51jvj1fvjn61jvdk51kd51k5d1"));

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                _repository.SessionToken.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repository.SaveAsync();

                return tokenHandler.WriteToken(token);
            }

            return "";
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, StandardUser user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
