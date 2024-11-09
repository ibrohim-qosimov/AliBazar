using AliBazar.Application.Services.CategoryServices;
using AliBazar.Application.Services.UserServices;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO userDTO)
        {
            var result = await _userService.CreateUser(userDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromForm] UserUpdateDTO userDTO)
        {
            var result = await _userService.UpdateUserById(id, userDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _userService.GetUserById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(long id)
        {
            var result = await _userService.DeleteUserById(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
