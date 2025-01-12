using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace GroceryGo_API.Repositories.Implementation
{
    public class SubcategoryRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), ISubcategoryRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;
        public async Task<List<Subcategory>> GetAllSubcategoriesByCategoryIdAsync(int categoryId)
        {
            return await DbContext.Subcategory.Where(sb => sb.CategoryId == categoryId).ToListAsync();
        }

        public async Task<int> AddSubcategoryAsync(SubcategoryDTO model)
        {
            var subcategory = new Subcategory
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
            };

            await DbContext.AddAsync(subcategory);
            await DbContext.SaveChangesAsync();

            return subcategory.Id;
        }
    }
}
