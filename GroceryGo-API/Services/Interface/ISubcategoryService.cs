using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface ISubcategoryService
    {
        public Task<List<Subcategory>> GetAllSubcategoriesByCategoryIdAsync(int categoryId);
        public Task<int> AddSubcategoryAsync(SubcategoryDTO model);
    }
}
