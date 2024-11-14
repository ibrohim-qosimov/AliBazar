using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace AliBazar.Application.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICateogryRepository _cateogryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryService(ICateogryRepository cateogryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _cateogryRepository = cateogryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> CreateCategory(CategoryDTO categoryDTO)
        {
            var fileName = await SaveFileAsync(categoryDTO.Image);

            if (fileName == null)
            {
                return new ResponseModel
                {
                    Note = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            var cateogry = new Category()
            {
                NameUz = categoryDTO.NameUz,
                NameRuss = categoryDTO.NameRuss,
                ImageUrl = "/CategoryPhotos/" + fileName
            };

            var result = await _cateogryRepository.Create(cateogry);

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
                Note = "Category created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteCategoryById(long id)
        {
            var deleteCategoryResult = await _cateogryRepository.Delete(x => x.Id == id);

            return deleteCategoryResult;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _cateogryRepository.GetAll();
        }

        public async Task<Category> GetCategoryById(long id)
        {
            var categoryResult = await _cateogryRepository.GetByAny(x => x.Id == id);
            return categoryResult;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllUz()
        {
            var categories = await _cateogryRepository.GetAll();
            var result = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.NameUz,
                ImageUrl = c.ImageUrl
            });

            return result;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllRu()
        {
            var categories = await _cateogryRepository.GetAll();
            var result = categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.NameRuss,
                ImageUrl = c.ImageUrl
            });

            return result;
        }

        public async Task<CategoryViewModel> GetCategoryByIdRu(long id)
        {
            var categoryResult = await _cateogryRepository.GetByAny(x => x.Id == id);

            return new CategoryViewModel()
            {
                Id= categoryResult.Id,
                Name = categoryResult.NameRuss,
                ImageUrl = categoryResult.ImageUrl
            };
        }

        public async Task<CategoryViewModel> GetCategoryByIdUz(long id)
        {
            var categoryResult = await _cateogryRepository.GetByAny(x => x.Id == id);

            return new CategoryViewModel()
            {
                Id = categoryResult.Id,
                Name = categoryResult.NameUz,
                ImageUrl = categoryResult.ImageUrl
            };
        }

        public async Task<ResponseModel> UpdateCategoryById(long id, CategoryDTO categoryDTO)
        {

            var category = await _cateogryRepository.GetByAny(x => x.Id == id);

            if (category == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "Category not found!"
                };
            }

            var fileName = await SaveFileAsync(categoryDTO.Image);

            if (fileName == null)
            {
                return new ResponseModel
                {
                    Note = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            category.NameUz = categoryDTO.NameUz;
            category.NameRuss = categoryDTO.NameRuss;
            category.ImageUrl = "/CategoryPhotos/" + fileName;

            var result = await _cateogryRepository.Update(category);

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
                Note = "Category updated successfully!",
                IsSuccess = true
            };
        }

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(filePath, fileName);

            try
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }
            catch
            {
                return null;
            }
        }
    }
}
