using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Services.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class OrderService : IOrderService
    {
        public required IOrderRepository OrderRepository { get; set; }

        public OrderService(IOrderRepository orderRepository)
        {
            this.OrderRepository = orderRepository;
        }

        public async Task PlaceOrder(OrderDTO model)
        {
            await OrderRepository.PlaceOrder(model);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            return await OrderRepository.GetOrdersByUserId(userId);
        }

        public async Task<IEnumerable<Product>> GetProductsByOrderId(int orderId)
        {
            return await OrderRepository.GetProductsByOrderId(orderId);
        }
    }
}
