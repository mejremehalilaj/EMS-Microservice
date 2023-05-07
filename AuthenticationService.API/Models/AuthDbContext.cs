using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.API.Models
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name="Admin", ConcurrencyStamp="1", NormalizedName="Admin"},
                new IdentityRole() { Name="User", ConcurrencyStamp="2", NormalizedName="User"},
                new IdentityRole() { Name="Parent", ConcurrencyStamp="3", NormalizedName="Parent"},
                new IdentityRole() { Name="Teacher", ConcurrencyStamp="4", NormalizedName="Teacher"}
                );
        }
    }
}
