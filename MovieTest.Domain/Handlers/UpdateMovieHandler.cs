using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Common.DTO;
using MovieTest.Common.Interfaces.Handlers;
using MovieTest.Common.Interfaces.Repositories;
using MovieTest.Common.Models;

namespace MovieTest.Domain.Handlers
{
    public class UpdateMovieHandler : BaseHandler, IUpdateMovieHandler
    {
        private readonly IMoviesrepository repository;

        public UpdateMovieHandler(IMoviesrepository repository, IMapper mapper)
            : base(mapper)
        {
            this.repository = repository;
        }

        public async Task<bool> GetResponseAsync(UpdateMovieRequest request)
        {
            try
            {
                var movie = this.mapper.Map<Movie>(request);
                await this.repository.Update(movie);
                await this.repository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                // ToDo:Log Exception
            }

            return false;
        }
    }
}
