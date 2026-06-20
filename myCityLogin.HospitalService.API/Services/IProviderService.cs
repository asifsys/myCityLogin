using myCityLogin.HospitalService.API.Models;

namespace myCityLogin.HospitalService.API.Services
{
    public interface IProviderService
    {
        Task<Provider> CreateAsync(ProviderRequest request);

    }
}
