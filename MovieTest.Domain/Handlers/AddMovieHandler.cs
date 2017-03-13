using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Data.Model;
using MovieTest.Data.Models;
using MovieTest.Data.Repositories;
using MovieTest.Domain.DTO;

namespace MovieTest.Domain.Handlers
{
    public interface IAddMovieHandler : IHandleApiRequestAsync<AddMovieRequest, bool>
    {
    }

    public class AddMovieHandler : IAddMovieHandler
    {
        private readonly IMoviesrepository repository;


        public AddMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> GetResponseAsync(AddMovieRequest request)
        {
            try
            {
                var movie = Mapper.Map<Movie>(request);
                await this.repository.Add(movie);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return false;
        }
    }
}
