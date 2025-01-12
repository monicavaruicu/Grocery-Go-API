using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Services.Implementation;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Controllers
{
    [Route("subcategory")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        public required ISubcategoryService SubcategoryService { get; set; }

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            this.SubcategoryService = subcategoryService;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Subcategory>> GetCategoriesAsync([FromQuery] int categoryId)
        {
            return await SubcategoryService.GetAllSubcategoriesByCategoryIdAsync(categoryId);
        }

        [HttpPost("add-subcategory")]
        public async Task<IActionResult> AddSubcategoryAsync([FromBody] SubcategoryDTO model)
        {
            var categoryId = await SubcategoryService.AddSubcategoryAsync(model);

            if (categoryId > 0)
            {
                return Ok(new { Id = categoryId });
            }

            return BadRequest();
        }
    }
}
