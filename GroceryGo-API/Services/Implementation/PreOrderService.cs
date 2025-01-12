using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;
using GroceryGo_API.Repositories.Interface;
using GroceryGo_API.Services.Interface;

namespace GroceryGo_API.Services.Implementation
{
    public class PreOrderService : IPreOrderService
    {
        public required IPreOrderRepository PreOrderRepository { get; set; }

        public PreOrderService(IPreOrderRepository preOrderRepository)
        {
            this.PreOrderRepository = preOrderRepository;
        }

        public async Task DeleteFromPreOrder(PreOrderDTO model)
        {
            await PreOrderRepository.DeleteFromPreOrder(model);
        }

        public async Task DeletePreOrder(int userId)
        {
            await PreOrderRepository.DeletePreOrder(userId);
        }

        public async Task<List<Product>> GetPreOrderByUserAsync(int userId)
        {
            var products = await PreOrderRepository.GetPreOrderByUserAsync(userId);
            return products;
        }

        public async Task AddToPreOrder(PreOrderDTO model)
        {
            await PreOrderRepository.AddToPreOrder(model);
        }
    }
}
