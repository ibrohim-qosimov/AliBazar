using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
            var file = categoryDTO.ImageUrl;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("Directory created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos", fileName);
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

            var cateogry = new Category()
            {
                Name = categoryDTO.Name,
                ImageUrl = "/CategoryPhotos/" + fileName
            };

            var result = await _cateogryRepository.Create(cateogry);

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
                ErrorNote = "Category created successfully!",
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

        public async Task<ResponseModel> UpdateCategoryById(long id, CategoryDTO categoryDTO)
        {

            var category = await _cateogryRepository.GetByAny(x => x.Id == id);

            if (category == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    ErrorNote = "Category not found!"
                };
            }

            var file = categoryDTO.ImageUrl;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("Directory created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CategoryPhotos", fileName);
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


            category.Name = categoryDTO.Name;
            category.ImageUrl = "/CategoryPhotos/" + fileName;

            var result = await _cateogryRepository.Update(category);

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
                ErrorNote = "Category updated successfully!",
                IsSuccess = true
            };
        }
    }
}
