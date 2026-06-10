using Microsoft.EntityFrameworkCore;
using myCityLogin.AccountService.API.Data;
using myCityLogin.AccountService.API.Interfaces;
using myCityLogin.AccountService.API.Models;

namespace myCityLogin.AccountService.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users
                .AnyAsync(x => x.Email == email);
        }
    }
}
