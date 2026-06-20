using Microsoft.EntityFrameworkCore;
using myCityLogin.AccountService.API.Data;
using myCityLogin.AccountService.API.Interfaces;
using myCityLogin.AccountService.API.Models;
using myCityLogin.AccountService.API.Services;

namespace myCityLogin.AccountService.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountDbContext _context;
        private readonly INotificationService _notificationService;

        public UserRepository(AccountDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<User> Register(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            await _notificationService.CreateNotificationAsync(user.Id, "Welcome", $"{user.FullName}, your account has been created successfully.");

            return user;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var userId = await _context.Users.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefaultAsync();
           
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
