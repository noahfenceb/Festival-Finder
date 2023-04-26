using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many
           

            //Many to Many

        }
    }

}
