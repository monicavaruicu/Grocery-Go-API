using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IPreOrderService
    {
        Task DeleteFromPreOrder(PreOrderDTO model);
        Task DeletePreOrder(int userId);
        Task<List<Product>> GetPreOrderByUserAsync(int userId);
        Task AddToPreOrder(PreOrderDTO model);
    }
}
