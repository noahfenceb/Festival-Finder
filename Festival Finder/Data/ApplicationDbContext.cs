using Festival_Finder.Models;
using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many
           

            //Many to Many

        }
    }

}
