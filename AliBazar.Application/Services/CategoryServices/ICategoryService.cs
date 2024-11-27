using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.CategoryServices
{
    public interface ICategoryService
    {

        public Task<ResponseModel> CreateCategory(CategoryDTO categoryDTO);
        public Task<ResponseModel> UpdateCategoryById(long id, CategoryDTO categoryDTO);
        public Task<bool> DeleteCategoryById(long id);
        public Task<CategoryViewModel> GetCategoryByIdRu(long id);
        public Task<CategoryViewModel> GetCategoryByIdUz(long id);
        public Task<IEnumerable<CategoryViewModel>> GetAllUz();
        public Task<IEnumerable<CategoryViewModel>> GetAllRu();
        public Task<Category> GetCategoryById(long id);
        public Task<IEnumerable<Category>> GetAllCategories();

    }
}
