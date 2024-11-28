using AliBazar.Application.Services.AdminServices;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _AdminService;

        public AdminController(IAdminServices AdminService)
        {
            _AdminService = AdminService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(Admin Admin)
        {
            var result = await _AdminService.CreateAdmin(Admin);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(long id, [FromForm] Admin Admin)
        {
            var result = await _AdminService.UpdateAdminById(id, Admin);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _AdminService.GetAllAdmins();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _AdminService.GetAdminById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAdmin(long id)
        {
            var result = await _AdminService.DeleteAdminById(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }

}