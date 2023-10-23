using Microsoft.EntityFrameworkCore;
using SampleAPI.Model;

namespace SampleAPI.Db
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<CityMaster> Cities { get; set; }

    }
}
