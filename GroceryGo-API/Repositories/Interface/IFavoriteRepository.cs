﻿using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Repositories.Interface
{
    public interface IFavoriteRepository
    {
        Task<List<Product>> GetFavoriteByUserAsync(int userId);
        Task RemoveFromFavorite(FavoriteDTO model);
        Task SaveFavorite(FavoriteDTO model);
    }
}
