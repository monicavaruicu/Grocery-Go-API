using GroceryGo_API.Entities;

namespace GroceryGo_API.Repository.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategoriesAsync();
    }
}
