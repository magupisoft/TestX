using System;
using System.Threading.Tasks;

using MovieTest.Data.Models;
using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public interface IGetMovieHandler : IHandleApiRequestAsync<Guid, Movie>
    {
    }

    public class GetMovieHandler : IGetMovieHandler
    {
        private readonly IMoviesrepository repository;

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
