using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GroceryGo_API.Controllers
{
    [Route("preorder")]
    [ApiController]
    public class PreOrderController : ControllerBase
    {
        public required IPreOrderService PreOrderService { get; set; }

        public PreOrderController(IPreOrderService preOrderService)
        {
            PreOrderService = preOrderService;
        }

        [HttpGet("get-preorder-by-user")]
        public async Task<IEnumerable<Product>> GetPreorderByUserAsync(int userId)
        {
            var products = await PreOrderService.GetPreOrderByUserAsync(userId);
            return products;
        }

        [HttpPost("add-to-preorder")]
        public async Task SavePreOrder([FromBody] PreOrderDTO model)
        {
            await PreOrderService.AddToPreOrder(model);
        }

        [HttpPost("delete-preorder")]
        public async Task DeletePreOrder([FromBody] int userId)
        {
            await PreOrderService.DeletePreOrder(userId);
        }

        [HttpPost("delete-from-preorder")]
        public async Task DeleteFromCart([FromBody] PreOrderDTO model)
        {
            await PreOrderService.DeleteFromPreOrder(model);
        }
    }
}
