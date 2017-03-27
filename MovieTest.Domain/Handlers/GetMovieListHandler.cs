using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Common.DTO;
using MovieTest.Common.Interfaces.Handlers;
using MovieTest.Common.Interfaces.Repositories;
using MovieTest.Common.Models;

namespace MovieTest.Domain.Handlers
{
    public class GetMovieListHandler : BaseHandler, IGetMovieListHandler
    {
         private readonly IMoviesrepository repository;

         public GetMovieListHandler(IMoviesrepository repository, IMapper mapper)
             : base(mapper)
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

            var moviesDetails = this.mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDetailResponse>>(movies);
            return moviesDetails;
        }
    }
}
