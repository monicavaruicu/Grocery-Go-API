using api.Repositories.Implementations;
using GroceryGo_API.Data;
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
    }
}
