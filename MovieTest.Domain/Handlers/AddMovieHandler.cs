using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public class AddMovieHandler
    {
        private IMoviesrepository repository;

        public AddMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }
    }
}
