using Microsoft.EntityFrameworkCore;
using ProjectDevice.API.Models;

namespace ProjectDevice.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
    }
}
