using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Implementation;
using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Repository.Interface;
using GroceryGo_API.Services.Interface;
using Shop_API.Repository.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class FavoriteService : IFavoriteService
    {
        public required IFavoriteRepository FavoriteRepository { get; set; }

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            this.FavoriteRepository = favoriteRepository;
        }

        public async Task<List<Product>> GetFavoriteByUserAsync(int userId)
        {
            var products = await FavoriteRepository.GetFavoriteByUserAsync(userId);
            return products;
        }

        public async Task RemoveFromFavorite(FavoriteDTO model)
        {
            await FavoriteRepository.RemoveFromFavorite(model);
        }

        public async Task SaveFavorite(FavoriteDTO model)
        {
            await FavoriteRepository.SaveFavorite(model);
        }
    }
}
