using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public required ICategoryService CategoryService { get; set; }

        public CategoryController(ICategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await CategoryService.GetCategoriesAsync();
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryDTO model)
        {
            var categoryId = await CategoryService.AddCategoryAsync(model);

            if (categoryId > 0)
            {
                return Ok(new { Id = categoryId });
            }

            return BadRequest();
        }
    }
}
