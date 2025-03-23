using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.ProductSizeServices
{
    public class ProductSizeService : IProductSizeService
    {

        private readonly IProductSizeRepository _repository;

        public ProductSizeService(IProductSizeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseModel> CreateProductSize(ProductSizeDTO detail)
        {
            var product = new ProductSize()
            {
                Size = detail.Size,
                ProductDetailId = detail.ProductDetailId
            };

            var result = await _repository.Create(product);


            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Error",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "ProductSIze created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteProductSize(int id)
        {
            var color = await _repository.Delete(x => x.Id == id);

            return true;
        }

        public async Task<IEnumerable<ProductSize>> GetAllProductSize()
        {
            return await _repository.GetAll();
        }

        public async Task<ProductSize> GetProductSizeById(int id)
        {
            var result = await _repository.GetByAny(x => x.Id == id);
            return result;
        }

        public async Task<ResponseModel> UpdateProducSize(int id, ProductSizeDTO detail)
        {
            var productDetail = await _repository.GetByAny(x => x.Id == id);

            if (productDetail == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "ProductColor not found!"
                };
            }



            productDetail.Size = detail.Size;
            productDetail.ProductDetailId = detail.ProductDetailId;

            var result = await _repository.Update(productDetail);



            return new ResponseModel()
            {
                Note = "ProductSize updated successfully!",
                IsSuccess = true
            };
        }
    }
}
