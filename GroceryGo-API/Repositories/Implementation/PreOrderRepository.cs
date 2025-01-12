using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GroceryGo_API.Repositories.Implementation
{
    public class PreOrderRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), IPreOrderRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;

        public async Task DeleteFromPreOrder(PreOrderDTO model)
        {
            var cartItem = await DbContext.PreOrder.FirstOrDefaultAsync(ci => ci.UserId == model.UserId && ci.ProductId == model.ProductId) ?? throw new KeyNotFoundException();

            DbContext.PreOrder.Remove(cartItem);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeletePreOrder(int userId)
        {
            var preOrders = await DbContext.PreOrder
                .Where(po => po.UserId == userId)
                .ToListAsync();

            DbContext.PreOrder.RemoveRange(preOrders);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetPreOrderByUserAsync(int userId)
        {
            var cartItemsIds = await DbContext.PreOrder
                .Where(f => f.UserId == userId)
                .Select(f => f.ProductId)
                .ToListAsync();

            var cartProducts = new List<Product>();

            foreach (var id in cartItemsIds)
            {
                var product = await DbContext.Product
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    cartProducts.Add(product);
                }
            }

            return cartProducts;
        }

        public async Task AddToPreOrder(PreOrderDTO model)
        {
            var cartItem = new PreOrder
            {
                UserId = model.UserId,
                ProductId = model.ProductId,
            };

            await DbContext.AddAsync(cartItem);
            await DbContext.SaveChangesAsync();
        }
    }
}
