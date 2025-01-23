using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string superAdminRoleId = "bbac3fa8-0c2e-4290-ae76-f015519030e9";
            string adminRoleId = "2665cbec-ec43-4baa-a6f9-ab26c77117e1";
            string userRoleId = "76018cd0-24a9-4f4e-a171-73802efb739e";


            // Seed roles (User, Admin, Super Admin)
            List<IdentityRole> roles = new List<IdentityRole> {
                new IdentityRole() {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole() {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole() {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Super Admin
            string superAdminId = "3749aa1b-8933-45c7-b8f5-a6efb6140a1a";

            IdentityUser superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "jorgews.dev@gmail.com",
                Email = "jorgews.dev@gmail.com"
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                                            .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add All Roles To Super Admin Roles
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId,
                },
                new IdentityUserRole<string>()
                {
                    RoleId = userRoleId,
                    UserId = superAdminId,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}
