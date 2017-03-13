using System.Collections.Generic;
using System.Threading.Tasks;

using MovieTest.Data.Model;
using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public class GetMovieListHandler : IHandleApiRequestAsync<IEnumerable<Movie>>
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
