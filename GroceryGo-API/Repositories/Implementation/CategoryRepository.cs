using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace GroceryGo_API.Repository.Implementation
{
    public class CategoryRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), ICategoryRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;

        public async Task<int> AddCategoryAsync(CategoryDTO model)
        {
            var category = new Category
            {
                Name = model.Name,
            };

            await DbContext.AddAsync(category);
            await DbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await DbContext.Category.ToListAsync();
        }
    }
}
