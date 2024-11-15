using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.ProductServices
{
    public interface IProductService
    {
        public Task<ResponseModel> CreateProduct(ProductDTO userDTO);
        public Task<ResponseModel> UpdateProductById(long id, ProductDTO userDTO);
        public Task<bool> DeleteProductById(long id);
        public Task<Product> GetProductById(long id);
        public Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<ProductViewModel>> GetAllUz();
        Task<IEnumerable<ProductViewModel>> GetAllRu();
        Task<ProductViewModel> GetProductByIdUz(long id);
        Task<ProductViewModel> GetProductByIdRu(long id);
    }
}
