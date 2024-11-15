using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.ViewModels
{
    public class ProductDTO
    {
        public required string Name { get; set; }
        public required string NameUz { get; set; }
        public required string NameRuss { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required long CategoryId { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
