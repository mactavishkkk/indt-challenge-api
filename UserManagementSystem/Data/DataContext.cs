global using Microsoft.EntityFrameworkCore;

namespace UserManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Port=5464;Host=host.docker.internal;Database=ums-db;Username=postgres;Password=postgres");
    }
}
