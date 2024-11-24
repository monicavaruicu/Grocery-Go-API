using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.Entities;
using Microsoft.EntityFrameworkCore;
using Shop_API.Repository.Interface;
using System.Data;

namespace GroceryGo_API.Repositories.Implementation
{
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        public ApplicationDbContext DbContext { get; set; }
        public ProviderRepository(IConfiguration configuration, ApplicationDbContext DbContext) : base(configuration)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<Provider>> GetProviders()
        {
            return await DbContext.Provider.ToListAsync();
        }

        public async Task<Provider> GetProviderById(int providerId)
        {
            return await DbContext.Provider.FindAsync(providerId) ?? throw new KeyNotFoundException();
        }
    }
}
