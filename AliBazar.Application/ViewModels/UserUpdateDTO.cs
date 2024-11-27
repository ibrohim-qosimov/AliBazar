using Microsoft.AspNetCore.Http;

namespace AliBazar.Application.ViewModels
{
    public class UserUpdateDTO
    {
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
