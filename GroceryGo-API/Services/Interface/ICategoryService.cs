using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoriesAsync();
    }
}
