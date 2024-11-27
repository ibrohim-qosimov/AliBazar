using AliBazar.Application.Services.GeneratingJWT;
using AliBazar.Application.Services.PasswrodHashing;
using AliBazar.Application.Services.UserServices;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(IUserService userService, IJwtService jwtService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userService.GetUserByPhoneNumber(model.PhoneNumber);

            var checkPassword = _passwordHasher.Verify(model.Password, user.Password, user.Salt);

            if (user == null || checkPassword == false)
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {

            var user = new CreateUserDTO()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password
            };

            await _userService.CreateUser(user);

            return Ok("User created successfully");
        }
    }
}
