using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Data.Models;
using MovieTest.Data.Repositories;
using MovieTest.Domain.DTO;

namespace MovieTest.Domain.Handlers
{
    public interface IGetMovieHandler : IHandleApiRequestAsync<Guid, MovieDetailResponse>
    {
    }

    public class GetMovieHandler : IGetMovieHandler
    {
        private readonly IMoviesrepository repository;

        public GetMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

        public async Task<MovieDetailResponse> GetResponseAsync(Guid request)
        {
            Movie movie = null;
            try
            {
                movie = await this.repository.GetByUnique(request);
            }
            catch (Exception ex)
            {                
                // ToDo: Log Exception
            }

            var movieDetail = Mapper.Map<MovieDetailResponse>(movie);
            return movieDetail;
        }
    }
}
