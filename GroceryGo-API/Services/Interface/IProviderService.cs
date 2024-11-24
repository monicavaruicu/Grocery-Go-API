using GroceryGo_API.Entities;

namespace GroceryGo_API.Services.Interface
{
    public interface IProviderService
    {
        Task<Provider> GetProviderById(int providerId);
        Task<List<Provider>> GetProviders();
    }
}
