using Azure.Core;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Services.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public required IProductRepository ProductRepository { get; set; } = productRepository;

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await ProductRepository.GetCategoriesAsync();
        }

        public async Task<List<Product>> GetProductsAsync(int subcategoryId)
        {
            return await ProductRepository.GetProductsAsync(subcategoryId);
        }

        //        public async Task<List<CategoryModel>> GetSubCategoriesAsync(int categroyId)
        //        {
        //            var subCategories = await _productRepository.GetSubCategoriesAsync(categroyId);
        //            return subCategories;
        //        }

        public async Task SaveProductAsync(ProductCreateDTO productCreateDTO)
        {
            await ProductRepository.SaveProductAsync(productCreateDTO);
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            await ProductRepository.UpdateProductAsync(productDTO);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await ProductRepository.DeleteProductAsync(productId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await ProductRepository.GetProductByIdAsync(productId);
        }

        //        public async Task<CategoryModel> GetCategoryBySubcategory(int subCategoryId)
        //        {
        //            var category = await _productRepository.GetCategoryBySubcategory(subCategoryId);
        //            return category;
        //        }

        //        public async Task<SubcategoryModel> GetSubcategoryById(int subCategoryId)
        //        {
        //            var category = await _productRepository.GetSubcategoryById(subCategoryId);
        //            return category;
        //        }
    }
}
