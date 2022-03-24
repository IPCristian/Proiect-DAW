using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect.Model.Entities;
using Proiect.Model.Entities.DTOs;
using Proiect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<StandardUser> _userManager;
        private readonly IUserService _userService;

        public AccountController(
            UserManager<StandardUser> userManager,
            IUserService userService
            )
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if (result)
            {
                return Ok("User created successfully.");
            }   

            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
