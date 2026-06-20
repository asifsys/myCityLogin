using myCityLogin.AccountService.API.Models;

namespace myCityLogin.AccountService.API.Interfaces
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(
            long userId,
            string title,
            string message);

        Task<List<Notification>> GetNotificationsAsync(
            long userId);

        Task<int> GetUnreadCountAsync(
            long userId);
    }
}
