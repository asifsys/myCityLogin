using Microsoft.EntityFrameworkCore;
using myCityLogin.HospitalService.API.Models;

namespace myCityLogin.HospitalService.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
    }
}
