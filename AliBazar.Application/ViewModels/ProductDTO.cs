using Microsoft.AspNetCore.Http;

namespace AliBazar.Application.ViewModels
{
    public class ProductDTO
    {
        public required string NameUz { get; set; }
        public required string NameRuss { get; set; }
        public string? DescriptionUz { get; set; }
        public string? DescriptionRuss { get; set; }
        public required decimal Price { get; set; }
        public required decimal PreviousPrice { get; set; }
        public required long CategoryId { get; set; }
        public List<IFormFile?> ImageUrl { get; set; }
    }
}
