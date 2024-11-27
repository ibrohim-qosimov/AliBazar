using AliBazar.Application.Services.CategoryServices;
using AliBazar.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromForm] CategoryDTO categoryDTO)
        {
            var result = await _categoryService.CreateCategory(categoryDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, [FromForm] CategoryDTO categoryDTO)
        {
            var result = await _categoryService.UpdateCategoryById(id, categoryDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _categoryService.GetCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("byLanguage")]
        public async Task<IActionResult> GetAllByLanguageAsync([FromHeader(Name = "Accept-Language")] string language = "uz")
        {
            IEnumerable<CategoryViewModel> result;
            switch (language)
            {
                case "uz":
                    result = await _categoryService.GetAllUz();
                    break;

                case "ru":
                    result = await _categoryService.GetAllRu();
                    break;

                default:
                    throw new Exception("Language not found");
            }
            return Ok(result);

        }
        [HttpGet("byLanguage/{id}")]
        public async Task<IActionResult> GetByIdByLanguage(long id, [FromHeader(Name = "Accept-Language")] string language = "uz")
        {
            CategoryViewModel result;
            switch (language)
            {
                case "uz":
                    result = await _categoryService.GetCategoryByIdUz(id);
                    break;

                case "ru":
                    result = await _categoryService.GetCategoryByIdRu(id);
                    break;

                default:
                    throw new Exception("Language not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(long id)
        {
            var result = await _categoryService.DeleteCategoryById(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
