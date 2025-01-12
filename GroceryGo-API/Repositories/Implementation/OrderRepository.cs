using api.Repositories.Implementations;
using GroceryGo_API.Data;
using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GroceryGo_API.Repositories.Implementation
{
    public class OrderRepository(IConfiguration configuration, ApplicationDbContext dbContext) : BaseRepository(configuration), IOrderRepository
    {
        public required ApplicationDbContext DbContext { get; set; } = dbContext;

        public async Task PlaceOrder(OrderDTO model)
        {
            var preOrders = await DbContext.PreOrder
                .Where(preOrder => preOrder.UserId == model.UserId)
                .ToListAsync();

            if (preOrders.Count == 0)
            {
                return;
            }

            var productIds = preOrders
                .Select(preOrder => preOrder.ProductId)
                .ToList();

            var products = new List<Product>();

            foreach (var id in productIds)
            {
                var product = await DbContext.Product
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    products.Add(product);
                }
            }

            var newOrder = new Order
            {
                Address = model.Address,
                PlacementDate = DateTime.UtcNow,
                UserId = model.UserId,
                OrderStatusId = 1,
                PaymentMethodId = model.PaymentMethodId,
                Total = model.Total
            };

            await DbContext.Order.AddAsync(newOrder);
            await DbContext.SaveChangesAsync();

            var orderId = newOrder.Id;

            var orderProducts = productIds.Select(productId => new OrderProduct
            {
                OrderId = newOrder.Id,
                ProductId = productId
            }).ToList();

            await DbContext.OrderProduct.AddRangeAsync(orderProducts);

            DbContext.PreOrder.RemoveRange(preOrders);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            var orders = await DbContext.Order
                .Where(o => o.UserId == userId)
                .ToListAsync();

            return orders;
        }

        public async Task<IEnumerable<Product>> GetProductsByOrderId(int orderId)
        {
            var orderProducts = await DbContext.OrderProduct
                .Where(op => op.OrderId == orderId)
                .ToListAsync();

            var productIds = orderProducts.Select(op => op.ProductId).ToList();

            var products = new List<Product>();

            foreach (var id in productIds)
            {
                var product = await DbContext.Product
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    products.Add(product);
                }
            }

            return products;
        }
    }
}
