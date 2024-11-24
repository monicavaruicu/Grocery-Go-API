using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Shop_API.Repository.Interface;

namespace Shop_API.BusinessLogic.Implementation
{
    public class ProviderService : IProviderService
    {
        public IProviderRepository ProviderRepository { get; set; }

        public ProviderService(IProviderRepository providerRepository)
        {
            this.ProviderRepository = providerRepository;
        }

        public async Task<List<Provider>> GetProviders()
        {
            return await ProviderRepository.GetProviders();
        }

        public async Task<Provider> GetProviderById(int providerId)
        {
            return await ProviderRepository.GetProviderById(providerId);
        }
    }
}
