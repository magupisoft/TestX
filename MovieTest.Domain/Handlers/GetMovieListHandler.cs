using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Data.Models;
using MovieTest.Data.Repositories;
using MovieTest.Domain.DTO;

namespace MovieTest.Domain.Handlers
{
    public interface IGetMovieListHandler : IHandleApiRequestAsync<IEnumerable<MovieDetailResponse>>
    {
    }

    public class GetMovieListHandler : IGetMovieListHandler
    {
         private readonly IMoviesrepository repository;

         public GetMovieListHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

         public async Task<IEnumerable<MovieDetailResponse>> GetResponseAsync()
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

            var moviesDetails = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDetailResponse>>(movies);
            return moviesDetails;
        }
    }
}
