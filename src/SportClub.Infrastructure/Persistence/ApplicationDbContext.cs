using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportClub.Domain.Entities;
using SportClub.Infrastructure.Identity;


namespace SportClub.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AuthenticationUser, AuthenticationRole, Guid>
    {
        public DbSet<AuthenticationUser> AuthenticationUsers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AuthenticationUser>().HasKey(o => o.Id); // Example configuration
            modelBuilder.Entity<UserProfile>().HasKey(o => o.Id); // Example configuration
            //modelBuilder.Entity<ApplicationUser>().HasKey(o => o.Id); // Example configuration
        }
    }
}
