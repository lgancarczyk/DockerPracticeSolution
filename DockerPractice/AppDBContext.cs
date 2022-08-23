using DockerPractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerPractice
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<RecipeModel> RecipeModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RecipeModel>()
                .HasKey(rm => rm.Id);
        }
    }
}
