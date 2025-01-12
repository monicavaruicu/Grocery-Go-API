using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Shop_API.Controllers
{
    [Route("favorite")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        public required IFavoriteService FavoriteService { get; set; }

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.FavoriteService = favoriteService;
        }

        [HttpGet("get-favorite-by-user")]
        public async Task<IEnumerable<Product>> GetFavoriteByUserAsync([FromQuery] int userId)
      {
            var products = await FavoriteService.GetFavoriteByUserAsync(userId);
            return products;
        }

        [HttpPost("save-favorite")]
        public async Task<IActionResult> SaveFavorite([FromBody] FavoriteDTO model)
        {
            try
            {
                await FavoriteService.SaveFavorite(model);
                return Ok();
            } 
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("remove-from-favorite")]
        public async Task RemoveFromFavorite([FromBody] FavoriteDTO model)
        {
            await FavoriteService.RemoveFromFavorite(model);
        }
    }
}
