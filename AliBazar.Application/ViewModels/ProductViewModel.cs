﻿using AliBazar.Domain.Entities;

namespace AliBazar.Application.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public List<string>? ImageUrl { get; set; }
        public ProductDetail? ProductDetails { get; set; }

    }
}
