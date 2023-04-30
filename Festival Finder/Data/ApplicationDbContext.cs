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
            //set up your connection for one to many (employer to jobs)
            //modelBuilder.Entity<Job>()
            //.HasOne(p => p.Employer)
            //.WithMany(b => b.Jobs);

            //set up your connection for many to many (skills to jobs)
            modelBuilder.Entity<Festival>()
            .HasMany(e => e.Artists)
            .WithMany(e => e.Festivals)
            .UsingEntity(j => j.ToTable("FestivalList"));
        }
    }

}
