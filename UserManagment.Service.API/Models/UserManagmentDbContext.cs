using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserManagment.Service.API.Models
{
    public class UserManagmentDbContext:IdentityDbContext<IdentityUser>
    {
        public UserManagmentDbContext(DbContextOptions<UserManagmentDbContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                new IdentityRole() { Name = "Student", ConcurrencyStamp = "3", NormalizedName = "Student" },
                new IdentityRole() { Name = "Parent", ConcurrencyStamp = "4", NormalizedName = "Parent" },
                new IdentityRole() { Name = "Teacher", ConcurrencyStamp = "5", NormalizedName = "Teacher" }
                );
        }
    }
}
