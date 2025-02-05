using AliBazar.Application.Services.ProductColorServices;
using AliBazar.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductColorController : ControllerBase
    {

        private readonly IProductColorService _productService;

        public ProductColorController(IProductColorService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductColor(ProductColorDTO color)
        {
            var result = await _productService.CreateProductColor(color);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductColor(int id)
        {
            var result = await _productService.DeleteProductColor(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductColor(int id, ProductColorDTO color)
        {
            var result = await _productService.UpdateProducColor(id, color);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductColor()
        {
            var result = await _productService.GetAllProductColor();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductColor(int id)
        {
            var result = await _productService.GetProductColorById(id);
            return Ok(result);
        }
    }
}
