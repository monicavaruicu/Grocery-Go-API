using GroceryGo_API.Entities;

namespace Shop_API.Repository.Interface
{
    public interface IProviderRepository
    {
        Task<Provider> GetProviderById(int providerId);
        Task<List<Provider>> GetProviders();
    }
}
