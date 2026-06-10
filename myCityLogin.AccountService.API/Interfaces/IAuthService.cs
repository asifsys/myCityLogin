using myCityLogin.AccountService.API.DTOs;

namespace myCityLogin.AccountService.API.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto dto);

        Task<string> Login(LoginDto dto);
    }
}