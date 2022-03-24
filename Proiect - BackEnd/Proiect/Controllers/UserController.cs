using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Proiect.Model.Entities;
using Proiect.Model.Entities.DTOs;
using Proiect.Repositories.UserRepository;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allusers = await _repository.GetAllUsers();

            var usersToReturn = new List<UserDTO>();

            foreach (var user in allusers)
            {
                usersToReturn.Add(new UserDTO(user));
            }

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "StandardUser")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetById(id);
            return Ok(new UserDTO(user));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            User newUser = new User();

            newUser.FirstName = dto.FirstName;
            newUser.LastName = dto.LastName;

            _repository.Create(newUser);

            await _repository.SaveAsync();

            return Ok(new UserDTO(newUser));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateNameById(int id, string LastName)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return NotFound("The specified ID isn't attributed to any user");
            }

            user.LastName = LastName;

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("The specified ID isn't attributed to any user");
            }

            _repository.Delete(user);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
