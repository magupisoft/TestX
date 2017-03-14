using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Data.Models;
using MovieTest.Data.Repositories;
using MovieTest.Domain.DTO;

namespace MovieTest.Domain.Handlers
{
    public interface IUpdateMovieHandler : IHandleApiRequestAsync<UpdateMovieRequest, bool>
    {
    }

    public class UpdateMovieHandler : IUpdateMovieHandler
    {
        private readonly IMoviesrepository repository;

        public UpdateMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> GetResponseAsync(UpdateMovieRequest request)
        {
            try
            {
                var movie = Mapper.Map<Movie>(request);
                await this.repository.Add(movie);
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
