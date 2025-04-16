using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportClub.Domain.Entities;


namespace SportClub.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasKey(o => o.Id); // Example configuration
            //modelBuilder.Entity<ApplicationUser>().HasKey(o => o.Id); // Example configuration
        }
    }
}
