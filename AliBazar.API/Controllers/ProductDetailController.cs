using AliBazar.Application.Services.ProductDetailsServices;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetails;

        public ProductDetailController(IProductDetailService productDetails)
        {
            _productDetails = productDetails;
        }





        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(ProductDetailDTO detail)
        {
            var result = await _productDetails.CreateProductDetail(detail);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductColor(int id)
        {
            var result = await _productDetails.DeleteProductDetail(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductColor(int id, ProductDetailDTO detail)
        {
            var result = await _productDetails.UpdateProducDetail(id, detail);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductColor()
        {
            var result = await _productDetails.GetAllProductDetail();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdProductColor(int id)
        {
            var result = await _productDetails.GetProductDetailById(id);
            return Ok(result);
        }
















    }
}
