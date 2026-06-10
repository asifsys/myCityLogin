using myCityLogin.HospitalService.API.Models;

namespace myCityLogin.HospitalService.API.Interfaces
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAll();
        Task<PagedResult<Hospital>> SearchAll(string? location, string? category, int page = 1, int pageSize = 10);
        Task<IEnumerable<Hospital>> Search(string? location, string? keyword);
        Task<Hospital?> GetById(int id);
        Task<Hospital> Create(Hospital hospital);
        Task<Hospital?> Update(int id, Hospital hospital);
        Task<bool> Delete(int id);
    }
}
