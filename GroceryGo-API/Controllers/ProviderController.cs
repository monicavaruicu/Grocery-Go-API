using GroceryGo_API.Entities;
using GroceryGo_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Shop_API.Controllers
{
    [Route("provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService ProviderService;

        public ProviderController(IProviderService providerService)
        {
            this.ProviderService = providerService;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Provider>> GetProviders()
        {
            return await ProviderService.GetProviders();
        }

        [HttpGet("get-provider-by-id")]
        public async Task<Provider> GetProviderById([FromQuery] int providerId)
        {
            return await ProviderService.GetProviderById(providerId);
        }
    }
}
