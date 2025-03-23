using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.ProductDetailsServices
{
    public class ProductDetailService : IProductDetailService
    {

        private readonly IProductDetailRepository _repositiry;

        public ProductDetailService(IProductDetailRepository repositiry)
        {
            _repositiry = repositiry;
        }

        public async Task<ResponseModel> CreateProductDetail(ProductDetailDTO detail)
        {
            var product = new ProductDetail()
            {
                ThisWeekPurchases = detail.ThisWeekPurchases,
                StockCount = detail.StockCount,
                ProductId = detail.ProductId,
            };

            var result = await _repositiry.Create(product);


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
                Note = "ProductDetail created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteProductDetail(int id)
        {
            var color = await _repositiry.Delete(x => x.Id == id);

            return true;
        }

        public async Task<IEnumerable<ProductDetail>> GetAllProductDetail()
        {
            return await _repositiry.GetAll();
        }

        public async Task<ProductDetail> GetProductDetailById(int id)
        {
            var result = await _repositiry.GetByAny(x => x.Id == id);
            return result;
        }

        public async Task<ResponseModel> UpdateProducDetail(int id, ProductDetailDTO detail)
        {
            var productDetail = await _repositiry.GetByAny(x => x.Id == id);

            if (productDetail == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "ProductColor not found!"
                };
            }



            productDetail.ThisWeekPurchases = detail.ThisWeekPurchases;
            productDetail.StockCount = detail.StockCount;
            productDetail.ProductId = detail.ProductId;

            var result = await _repositiry.Update(productDetail);



            return new ResponseModel()
            {
                Note = "ProductDetail updated successfully!",
                IsSuccess = true
            };

        }
    }
}
