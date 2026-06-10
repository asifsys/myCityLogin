using Microsoft.EntityFrameworkCore;
using myCityLogin.AccountService.API.Models;

namespace myCityLogin.AccountService.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
