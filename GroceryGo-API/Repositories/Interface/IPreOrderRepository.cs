using GroceryGo_API.DTOs;
using GroceryGo_API.Entities;

namespace GroceryGo_API.Repositories.Interface
{
    public interface IPreOrderRepository
    {
        Task DeleteFromPreOrder(PreOrderDTO model);
        Task DeletePreOrder(int userId);
        Task<List<Product>> GetPreOrderByUserAsync(int userId);
        Task AddToPreOrder(PreOrderDTO model);
    }
}
