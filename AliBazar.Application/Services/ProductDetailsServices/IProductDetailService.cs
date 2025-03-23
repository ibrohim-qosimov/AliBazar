using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.ProductDetailsServices
{
    public interface IProductDetailService
    {
        public Task<ResponseModel> CreateProductDetail(ProductDetailDTO detail);
        public Task<bool> DeleteProductDetail(int id);
        public Task<ResponseModel> UpdateProducDetail(int id, ProductDetailDTO detail);
        public Task<IEnumerable<ProductDetail>> GetAllProductDetail();
        public Task<ProductDetail> GetProductDetailById(int id);
    }
}
