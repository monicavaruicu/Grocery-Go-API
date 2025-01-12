using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IFavoriteService
    {
        Task<List<Product>> GetFavoriteByUserAsync(int userId);
        Task RemoveFromFavorite(FavoriteDTO model);
        Task SaveFavorite(FavoriteDTO model);
    }
}
