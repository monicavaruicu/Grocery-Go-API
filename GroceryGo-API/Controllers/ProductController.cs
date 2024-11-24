using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public required IProductService ProductService { get; set; }

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Product>> GetProductsAsync([FromQuery] int subcategoryId)
        {
            return await ProductService.GetProductsAsync(subcategoryId);
        }

        [HttpGet("get-product-by-id")]
        public async Task<Product> GetProductByIdAsync([FromQuery] int productId)
        {
            return await ProductService.GetProductByIdAsync(productId);
        }

        [HttpPost("save-product")]
        public async Task SaveProductsAsync([FromBody] ProductCreateDTO productCreateDTO)
        {
            await ProductService.SaveProductAsync(productCreateDTO);
        }


        [HttpPost("update-product")]
        public async Task UpdateProductsAsync([FromBody] ProductDTO productDTO)
        {
            await ProductService.UpdateProductAsync(productDTO);
        }

        [HttpPost("delete-product")]
        public async Task DeleteProductsAsync([FromQuery] int productId)
        {
            await ProductService.DeleteProductAsync(productId);
        }

        //        [HttpGet("get-category-by-subcategory")]
        //        public async Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId)
        //        {
        //            var category = await _productBL.GetCategoryBySubcategory(subCategoryId);
        //            return category;
        //        }

        //        [HttpGet("get-subcategory-by-id")]
        //        public async Task<SubcategoryModel> GetSubcategoryById(int subCategoryId)
        //        {
        //            var category = await _productBL.GetSubcategoryById(subCategoryId);
        //            return category;
        //        }
    }
}
