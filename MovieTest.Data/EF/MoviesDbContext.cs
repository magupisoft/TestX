using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using MovieTest.Common.Models;

namespace MovieTest.Data.EF
{
    [DbConfigurationType(typeof(DatabaseConfiguration))] 
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("name=MoviesDB")
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Defines Primary Key
            modelBuilder.Entity<Movie>().HasKey(t => t.Id);
            modelBuilder.Entity<Movie>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Movie>().Property(t => t.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Movie>().Property(t => t.Description).IsOptional().HasMaxLength(500);
            modelBuilder.Entity<Movie>().Property(t => t.Classification).IsRequired().HasMaxLength(5);
            modelBuilder.Entity<Movie>().Property(t => t.Duration).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Movie>().Property(t => t.Genres).IsRequired().HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}
