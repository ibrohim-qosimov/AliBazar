using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace AliBazar.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> CreateProduct(ProductDTO productDTO)
        {
            var file = productDTO.ImageUrl;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("Product created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            var product = new Product()
            {
                Name = productDTO.Name,
                NameRuss = productDTO.NameRuss,
                NameUz = productDTO.NameUz,
                Description = productDTO.Description,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId,
                ImageUrl = "/ProductPhotos/" + fileName
            };

            var result = await _productRepository.Create(product);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "Product created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var deleteProductResult = await _productRepository.Delete(x => x.Id == id);

            return deleteProductResult;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(long id)
        {
            var ProductResult = await _productRepository.GetByAny(x => x.Id == id);
            return ProductResult;
        }


        public async Task<IEnumerable<ProductViewModel>> GetAllUz()
        {
            var products = await _productRepository.GetAll();
            var result = products.Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.NameUz,
                ImageUrl = c.ImageUrl
            }); 
            return result;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllRu()
        {
            var products = await _productRepository.GetAll();
            var result = products.Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.NameRuss,
                ImageUrl = c.ImageUrl
            });
            return result;
        }

        public async Task<ResponseModel> UpdateProductById(long id, ProductDTO productDTO)
        {

            var product = await _productRepository.GetByAny(x => x.Id == id);

            if (product == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "Product not found!"
                };
            }

            var file = productDTO.ImageUrl;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("Product created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            product.Name = productDTO.Name;
            product.NameUz = productDTO.NameUz;
            product.NameRuss = productDTO.NameRuss;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.CategoryId = productDTO.CategoryId;
            product.Name = productDTO.Name;
            product.ImageUrl = "/ProductPhotos/" + fileName;

            var result = await _productRepository.Update(product);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "Product updated successfully!",
                IsSuccess = true
            };
        }

        public async Task<ProductViewModel> GetProductByIdUz(long id)
        {

            var product = await _productRepository.GetByAny(x => x.Id == id);

            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.NameUz,
                ImageUrl = product.ImageUrl
            };
        }
        
        

        public async Task<ProductViewModel> GetProductByIdRu(long id)
        {
            var product = await _productRepository.GetByAny(x => x.Id == id);

            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.NameRuss,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
