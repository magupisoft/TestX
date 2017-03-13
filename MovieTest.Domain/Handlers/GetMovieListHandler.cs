using System.Collections.Generic;
using System.Threading.Tasks;

using MovieTest.Data.Models;
using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public interface IGetMovieListHandler : IHandleApiRequestAsync<IEnumerable<Movie>>
    {
    }

    public class GetMovieListHandler : IGetMovieListHandler
    {
         private readonly IMoviesrepository repository;

         public GetMovieListHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Movie>> GetResponseAsync()
        {
            return await this.repository.GetMovies();
        }
    }
}
