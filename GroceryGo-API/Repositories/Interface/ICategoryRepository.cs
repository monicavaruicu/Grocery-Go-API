using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Repository.Interface
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<int> AddCategoryAsync(CategoryDTO model);
    }
}
