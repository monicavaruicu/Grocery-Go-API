using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IOrderService
    {
        Task PlaceOrder(OrderDTO model);
        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
        Task<IEnumerable<Product>> GetProductsByOrderId(int orderId);
    }
}
