using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public class UpdateMovieHandler
    {
        private IMoviesrepository repository;

        public UpdateMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }
    }
}
