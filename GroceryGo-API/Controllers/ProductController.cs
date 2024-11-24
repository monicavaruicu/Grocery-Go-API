//using GroceryGo_API.DTOs;
//using GroceryGo_API.Services.Interface;
//using Microsoft.AspNetCore.Mvc;
//using Shop_API.Models.Product;

//namespace GroceryGo_API.Controllers
//{
//    [Route("product")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        public required IProductService ProductService { get; set; }

//        public ProductController(IProductService productService)
//        {
//            ProductService = productService;
//        }

//        [HttpGet("get-products")]
//        public async Task<IEnumerable<ProductModel>> GetProductsAsync([FromQuery] ProductRequestDTO productRequestDTO)
//        {
//            return await ProductService.GetProductsAsync(productRequestDTO);
//        }

//        [HttpGet("get-product-by-id")]
//        public async Task<ProductModel> GetProductByIdAsync([FromQuery] int productId)
//        {
//            var product = await _productBL.GetProductByIdAsync(productId);
//            return product;
//        }

//        [HttpGet("get-categories")]
//        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
//        {
//            var categories = await _productBL.GetCategoriesAsync();
//            return categories;
//        }

//        [HttpGet("get-subcategories")]
//        public async Task<IEnumerable<CategoryModel>> GetSubCategoriesAsync([FromQuery] int categoryId)
//        {
//            var subCategories = await _productBL.GetSubCategoriesAsync(categoryId);
//            return subCategories;
//        }

//        [HttpPost("save-product")]
//        public async Task SaveProductsAsync([FromBody] SaveProductRequest request)
//        {
//            await _productBL.SaveProductsAsync(request);
//        }


//        [HttpPost("update-product")]
//        public async Task UpdateProductsAsync([FromBody] ProductModel request)
//        {
//            await _productBL.UpdateProductsAsync(request);
//        }

//        [HttpPost("delete-product")]
//        public async Task DeleteProductsAsync([FromQuery] int productId)
//        {
//            await _productBL.DeleteProductsAsync(productId);
//        }

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
//    }
//}
