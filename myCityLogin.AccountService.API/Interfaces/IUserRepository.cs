using myCityLogin.AccountService.API.Models;

namespace myCityLogin.AccountService.API.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user);

        Task<User?> GetByEmail(string email);

        Task<bool> UserExists(string email);
    }
}
