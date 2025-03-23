using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.ProductSizeServices
{
    public interface IProductSizeService
    {
        public Task<ResponseModel> CreateProductSize(ProductSizeDTO detail);
        public Task<bool> DeleteProductSize(int id);
        public Task<ResponseModel> UpdateProducSize(int id, ProductSizeDTO detail);
        public Task<IEnumerable<ProductSize>> GetAllProductSize();
        public Task<ProductSize> GetProductSizeById(int id);
    }
}
