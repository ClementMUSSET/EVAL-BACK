using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Entities;


namespace PasswordManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Password> Passwords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasMany(a => a.Passwords)
                .WithOne(p => p.Application)
                .HasForeignKey(p => p.ApplicationId);
        }
    }
}
