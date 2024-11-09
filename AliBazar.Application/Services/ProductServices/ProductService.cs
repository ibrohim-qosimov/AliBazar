using AliBazar.Application.Abstractions;
using AliBazar.Application.Services.CategoryServices;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    ErrorNote = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            var product = new Product()
            {
                Name = productDTO.Name,
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
                    ErrorNote = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                ErrorNote = "Product created successfully!",
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

        public async Task<ResponseModel> UpdateProductById(long id, ProductDTO productDTO)
        {

            var product = await _productRepository.GetByAny(x => x.Id == id);

            if (product == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    ErrorNote = "Product not found!"
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
                    ErrorNote = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            product.Name = productDTO.Name;
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
                    ErrorNote = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                ErrorNote = "Product updated successfully!",
                IsSuccess = true
            };
        }

    }
}
