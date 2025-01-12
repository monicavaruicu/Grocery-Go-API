using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repository.Interface;
using GroceryGo_API.Services.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class CategoryService: ICategoryService
    {
        public required ICategoryRepository CategoryRepository { get; set; }
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await CategoryRepository.GetCategoriesAsync();
        }

        public async Task<int> AddCategoryAsync(CategoryDTO model)
        {
            return await CategoryRepository.AddCategoryAsync(model);
        }
    }
}
