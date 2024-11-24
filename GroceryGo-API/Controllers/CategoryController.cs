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
    }
}
