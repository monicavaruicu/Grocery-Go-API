using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IProductService
    {
        Task<List<Category>> GetCategoriesAsync();
        //Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<List<Product>> GetProductsAsync(int subcategoryId);
        //Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId);
        //Task<SubcategoryModel> GetSubcategoryById(int subCategoryId);
        Task SaveProductAsync(ProductCreateDTO productCreateDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int productId);
    }
}
