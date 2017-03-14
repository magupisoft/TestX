using System;
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
            IEnumerable<Movie> movies = null;
            try
            {
                movies = await this.repository.GetMovies();
            }
            catch (Exception ex)
            {

                // ToDo: Log Exception
            }

            return movies;
        }
    }
}
