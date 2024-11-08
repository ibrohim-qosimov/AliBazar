using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("smthng");
        }
    }
}
