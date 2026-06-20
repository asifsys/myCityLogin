using Microsoft.EntityFrameworkCore;
using myCityLogin.AccountService.API.Models;

namespace myCityLogin.AccountService.API.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext( DbContextOptions<AccountDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
