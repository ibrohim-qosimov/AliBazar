﻿using AliBazar.Application.Services.CategoryServices;
using AliBazar.Application.Services.ProductServices;
using AliBazar.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDTO productDTO)
        {
            var result = await _productService.CreateProduct(productDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, [FromForm] ProductDTO productDTO)
        {
            var result = await _productService.UpdateProductById(id, productDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _productService.GetProductById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(long id)
        {
            var result = await _productService.DeleteProductById(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}