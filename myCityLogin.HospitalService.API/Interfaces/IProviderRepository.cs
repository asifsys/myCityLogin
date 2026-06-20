using myCityLogin.HospitalService.API.Models;

namespace myCityLogin.HospitalService.API.Interfaces
{
    public interface IProviderRepository
    {
        Task<Provider> CreateAsync(Provider provider);

    }
}
