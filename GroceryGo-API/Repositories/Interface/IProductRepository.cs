using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Product>> GetProductsAsync(int subcategoryId);
        Task SaveProductAsync(ProductCreateDTO productCreateDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteProductAsync(int productId);
        Task<Product> GetProductByIdAsync(int productId);

        //    Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId);
        //    Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId);
        //    Task<SubcategoryModel> GetSubcategoryById(int subCategoryId);
    }
}
