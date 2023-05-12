using Festival_Finder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SaveFestival> SaveFestivals { get; set; }
       


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed data for roles => admin, user and super-user
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = "1",
                    ConcurrencyStamp = "1"
                },

                //new IdentityRole
                //{
                //    Name = "SuperAdmin",
                //    NormalizedName = "SuperAdmin",
                //    Id = 2,
                //    ConcurrencyStamp = 2
                //},

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = "2",
                    ConcurrencyStamp = "2"
                }

            };

            builder.Entity<IdentityRole>().HasData(roles);

            //seed admin user
            var adminUser = new AppUser
            {
                UserName = "admin@yahoo.com",
                Email = "admin@yahoo.com",
                NormalizedEmail = "admin@yahoo.com".ToUpper(),
                NormalizedUserName = "admin@yahoo.com".ToUpper(),
                Id = "1"
            };

            adminUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(adminUser, "admin123");

            builder.Entity<AppUser>().HasData(adminUser);

            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = adminUser.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = adminUser.Id
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }


    }

}
