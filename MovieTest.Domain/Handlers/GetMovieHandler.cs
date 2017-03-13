using System;
using System.Threading.Tasks;

using MovieTest.Data.Model;
using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public class GetMovieHandler : IHandleApiRequestAsync<Guid, Movie>
    {
        private IMoviesrepository repository;

        public GetMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

        public async Task<Movie> GetResponseAsync(Guid request)
        {
            return await this.repository.GetByUnique(request);
        }
    }
}
