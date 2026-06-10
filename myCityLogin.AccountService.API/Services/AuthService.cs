using myCityLogin.AccountService.API.DTOs;
using myCityLogin.AccountService.API.Interfaces;
using myCityLogin.AccountService.API.Models;
using myCityLogin.AccountService.API.Services;

namespace myCityLogin.AccountService.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthService(
            IUserRepository repository,
            JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            if (await _repository.UserExists(dto.Email))
            {
                return "User already exists";
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _repository.Register(user);

            return "Registration Successful";
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _repository.GetByEmail(dto.Email);

            if (user == null)
            {
                return "Invalid credentials";
            }

            bool passwordValid = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

            if (!passwordValid)
            {
                return "Invalid credentials";
            }

            return _jwtService.GenerateToken(user);
        }
    }
}
