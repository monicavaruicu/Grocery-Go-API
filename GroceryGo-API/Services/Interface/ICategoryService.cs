using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Services.Interface
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<int> AddCategoryAsync(CategoryDTO model);
    }
}
