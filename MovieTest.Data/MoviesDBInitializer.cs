using System.Collections.Generic;
using System.Data.Entity;

using MovieTest.Data.Models;

namespace MovieTest.Data
{
    public class MoviesDBInitializer : DropCreateDatabaseIfModelChanges<MoviesDbContext>
    {
        public override void InitializeDatabase(MoviesDbContext context)
        {
            // If an existing connection exists when trying to re-create DB, it drops out
            context.Database.ExecuteSqlCommand(
                TransactionalBehavior.DoNotEnsureTransaction,
                string.Format(
                    "ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
                    context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(MoviesDbContext context)
        {
            IList<Movie> movies = new List<Movie>
                                      {
                                          new Movie
                                              {
                                                  Title = "The Godfather",
                                                  Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                                                  Classification = "C",
                                                  Duration = "2h 55min",
                                                  Genres = "Crime, Drame"
                                              },
                                          new Movie
                                              {
                                                  Title = "The Dark Knight",
                                                  Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, the caped crusader must come to terms with one of the greatest psychological tests of his ability to fight injustice.",
                                                  Classification = "B",
                                                  Duration = "2h 32min",
                                                  Genres = "Action, Crime, Drama"
                                              },
                                          new Movie
                                              {
                                                  Title = "Schindler's List",
                                                  Description = "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans.",
                                                  Classification = "R",
                                                  Duration = "3h 15min",
                                                  Genres = "Biography, Drama, History"
                                              },
                                          new Movie
                                              {
                                                  Title = "The Lord of the Rings",
                                                  Description = "Gandalf and Aragorn lead the World of Men against Sauron\'s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                                                  Classification = "PG-13",
                                                  Duration = "3h 21min",
                                                  Genres = "Adventure, Drama, Fantasy"
                                              },
                                      };
        
            foreach (var movie in movies)
            {
                context.Movies.Add(movie);
            }

            base.Seed(context);
        }
    }
}
