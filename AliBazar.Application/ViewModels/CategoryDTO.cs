using Microsoft.AspNetCore.Http;

namespace AliBazar.Application.ViewModels
{
    public class CategoryDTO
    {
        public required string NameUz { get; set; }
        public required string NameRuss { get; set; }
        public IFormFile? Image { get; set; }
    }
}
