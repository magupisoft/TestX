using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Common.DTO;
using MovieTest.Common.Interfaces.Handlers;
using MovieTest.Common.Interfaces.Repositories;
using MovieTest.Common.Models;

namespace MovieTest.Domain.Handlers
{
    public class GetMovieHandler : BaseHandler, IGetMovieHandler
    {
        private readonly IMoviesrepository repository;

        public GetMovieHandler(IMoviesrepository repository, IMapper mapper)
            : base(mapper)
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

            var movieDetail = this.mapper.Map<MovieDetailResponse>(movie);
            return movieDetail;
        }
    }
}
