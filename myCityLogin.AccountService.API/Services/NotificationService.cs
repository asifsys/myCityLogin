using Microsoft.EntityFrameworkCore;
using myCityLogin.AccountService.API.Data;
using myCityLogin.AccountService.API.Interfaces;
using myCityLogin.AccountService.API.Models;

namespace myCityLogin.AccountService.API.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AccountDbContext _context;

        public NotificationService(
            AccountDbContext context)
        {
            _context = context;
        }

        public async Task CreateNotificationAsync(long userId, string title, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Title = title,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Notification>>
            GetNotificationsAsync(long userId)
        {
            return await _context.Notifications.Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<int>
            GetUnreadCountAsync(long userId)
        {
            return await _context.Notifications.CountAsync(x => x.UserId == userId && !x.IsRead);
        }
    }
}
