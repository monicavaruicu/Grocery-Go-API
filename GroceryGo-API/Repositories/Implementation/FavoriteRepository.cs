using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GroceryGo_API.Repositories.Implementation
{
    public class FavoriteRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), IFavoriteRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;

        public async Task<List<Product>> GetFavoriteByUserAsync(int userId)
        {
            var favoriteProductIds = await DbContext.Favorite
                .Where(f => f.UserId == userId)
                .Select(f => f.ProductId)
                .ToListAsync();

            var favoriteProducts = DbContext.Product
                .Where(p => favoriteProductIds.Contains(p.Id))
                .ToListAsync();

            return await favoriteProducts;
        }

        public async Task RemoveFromFavorite(FavoriteDTO model)
        {
            var favoriteItem = await DbContext.Favorite.FirstOrDefaultAsync(fi => fi.UserId == model.UserId && fi.ProductId == model.ProductId) ?? throw new KeyNotFoundException();

            DbContext.Favorite.Remove(favoriteItem);
            await DbContext.SaveChangesAsync();
        }

        public async Task SaveFavorite(FavoriteDTO favoriteModel)
        {
            var existingFavorite = await DbContext.Favorite
                .FirstOrDefaultAsync(f => f.UserId == favoriteModel.UserId && f.ProductId == favoriteModel.ProductId);

            if (existingFavorite != null)
            {
                throw new InvalidOperationException("Product already exists in favorites list!");
            }

            var favoriteItem = new Favorite
            {
                UserId = favoriteModel.UserId,
                ProductId = favoriteModel.ProductId,
            };

            await DbContext.AddAsync(favoriteItem);
            await DbContext.SaveChangesAsync();
        }
    }
}
