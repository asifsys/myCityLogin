using myCityLogin.HospitalService.API.Data;
using myCityLogin.HospitalService.API.Interfaces;
using myCityLogin.HospitalService.API.Models;

namespace myCityLogin.HospitalService.API.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly HospitalDbContext _context;

        public ProviderRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<Provider> CreateAsync(Provider provider)
        {
            _context.Providers.Add(provider);

            await _context.SaveChangesAsync();

            return provider;
        }
    }
}
