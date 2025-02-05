using AliBazar.Application.Services.ProductSizeServices;
using AliBazar.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {

        private readonly IProductSizeService _productSize;

        public ProductSizeController(IProductSizeService productSize)
        {
            _productSize = productSize;
        }




        [HttpPost]
        public async Task<IActionResult> CreateProductSize(ProductSizeDTO detail)
        {
            var result = await _productSize.CreateProductSize(detail);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSize(int id)
        {
            var result = await _productSize.DeleteProductSize(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductSize(int id, ProductSizeDTO detail)
        {
            var result = await _productSize.UpdateProducSize(id, detail);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductSize()
        {
            var result = await _productSize.GetAllProductSize();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductSize(int id)
        {
            var result = await _productSize.GetProductSizeById(id);
            return Ok(result);
        }
    }
}
