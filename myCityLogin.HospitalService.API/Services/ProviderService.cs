using myCityLogin.HospitalService.API.Interfaces;
using myCityLogin.HospitalService.API.Models;
using System.Text.Json;

namespace myCityLogin.HospitalService.API.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Provider> CreateAsync(ProviderRequest request)
        {
            var provider = new Provider
            {
                ProviderCode = "PRV" + DateTime.Now.Ticks,
                ProviderJson = JsonSerializer.Serialize(request),
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
                
            };

            return await _providerRepository.CreateAsync(provider);
        }
    }
}
