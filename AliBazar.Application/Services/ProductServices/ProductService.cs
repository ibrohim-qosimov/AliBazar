using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            string productFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", Guid.NewGuid().ToString());
            List<string> imageUrls = new List<string>();

            try
            {
                foreach (var file in productDTO.ImageUrl)
                {
                    var savedFilePath = await SaveFileAsync(file, productFolderPath);
                    if (savedFilePath != null)
                    {
                        imageUrls.Add(savedFilePath);
                    }
                }
            }
            catch
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving pictures.",
                    IsSuccess = false
                };
            }

            var product = new Product()
            {
                NameRuss = productDTO.NameRuss,
                NameUz = productDTO.NameUz,
                DescriptionUz = productDTO.DescriptionUz,
                DescriptionRuss = productDTO.DescriptionRuss,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId,
                ImageUrl = imageUrls
            };

            var result = await _productRepository.Create(product);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving product.",
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
                Description = c.DescriptionUz,
                Price = c.Price,
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
                Description = c.DescriptionRuss,
                Price = c.Price,
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

            string productFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPhotos", product.Id.ToString());
            List<string> imageUrls = new List<string>();

            try
            {
                if (productDTO.ImageUrl != null && productDTO.ImageUrl.Count > 0)
                {
                    foreach (var file in productDTO.ImageUrl)
                    {
                        var savedFilePath = await SaveFileAsync(file, productFolderPath);
                        if (savedFilePath != null)
                        {
                            imageUrls.Add(savedFilePath);
                        }
                    }
                    product.ImageUrl = imageUrls;
                }
            }
            catch
            {
                return new ResponseModel()
                {
                    Note = "Exception while saving pictures.",
                    IsSuccess = false
                };
            }

            product.NameUz = productDTO.NameUz;
            product.NameRuss = productDTO.NameRuss;
            product.DescriptionUz = productDTO.DescriptionUz;
            product.DescriptionRuss = productDTO.DescriptionRuss;
            product.Price = productDTO.Price;
            product.CategoryId = productDTO.CategoryId;

            var result = await _productRepository.Update(product);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Exception while updating product.",
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
                Description = product.DescriptionUz,
                Price = product.Price,
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
                Description = product.DescriptionRuss,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
        }

        private async Task<string> SaveFileAsync(IFormFile file, string productFolderPath)
        {
            if (file == null || file.Length == 0) return null;

            if (!Directory.Exists(productFolderPath))
            {
                Directory.CreateDirectory(productFolderPath);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(productFolderPath, fileName);

            try
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return $"/ProductPhotos/{Path.GetFileName(productFolderPath)}/{fileName}";
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> SearchProduct(string name)
        {
            var result = await _productRepository.GetAll();

            var filteredResult = result.Where(c=>c.NameUz.Contains(name) || c.NameRuss.Contains(name));

            return filteredResult;
        }
    }
}
