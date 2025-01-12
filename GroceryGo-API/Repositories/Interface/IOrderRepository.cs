using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task PlaceOrder(OrderDTO model);
        Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
        Task<IEnumerable<Product>> GetProductsByOrderId(int orderId);
    }
}
