using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IProductService
    {
        //Task DeleteProductsAsync(int productId);
        Task<List<Category>> GetCategoriesAsync();
        //Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId);
        //Task<ProductModel> GetProductByIdAsync(int productId);
        //Task<List<ProductModel>> GetProductsAsync(GetProductModelRequest request);
        //Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId);
        //Task<SubcategoryModel> GetSubcategoryById(int subCategoryId);
        //Task SaveProductsAsync(SaveProductRequest request);
        //Task UpdateProductsAsync(ProductModel request);
    }
}
