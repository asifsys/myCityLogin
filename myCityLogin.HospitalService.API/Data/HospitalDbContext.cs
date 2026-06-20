using Microsoft.EntityFrameworkCore;
using myCityLogin.HospitalService.API.Models;

namespace myCityLogin.HospitalService.API.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext( DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
