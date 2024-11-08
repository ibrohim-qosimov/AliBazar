using Microsoft.AspNetCore.Http;

namespace AliBazar.Application.ViewModels
{
    public class CategoryDTO
    {
        public required string Name { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
