using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public required IOrderService OrderService { get; set; }

        public OrderController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }

        [HttpPost("place-order")]
        public async Task PlaceOrder([FromBody] OrderDTO model)
        {
            await OrderService.PlaceOrder(model);
        }

        [HttpGet("get-orders")]
        public async Task<IEnumerable<Order>> GetOrders([FromQuery] int userId)
        {
            return await OrderService.GetOrdersByUserId(userId);
        }

        [HttpGet("get-order-products")]
        public async Task<IEnumerable<Product>> GetOrderProducts([FromQuery] int orderId)
        {
            return await OrderService.GetProductsByOrderId(orderId);
        }
    }
}
