using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using MovieTest.Data.Model;

namespace MovieTest.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }

        public MoviesDbContext() : base("name=MoviesDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Defines Primary Key
            modelBuilder.Entity<Movies>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Movies>().Property(t => t.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Movies>().Property(t => t.Description).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Movies>().Property(t => t.Classification).IsRequired().HasMaxLength(5);
            modelBuilder.Entity<Movies>().Property(t => t.Duration).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Movies>().Property(t => t.Genres).IsRequired().HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}
