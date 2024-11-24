using GroceryGo_API.Entities;

namespace GroceryGo_API.Repositories.Interface
{
    public interface ISubcategoryRepository
    {
        public Task<List<Subcategory>> GetAllSubcategoriesByCategoryIdAsync(int categoryId);
    }
}
