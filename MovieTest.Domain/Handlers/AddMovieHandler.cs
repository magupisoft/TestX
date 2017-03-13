using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Data.Model;
using MovieTest.Data.Repositories;
using MovieTest.Domain.Models;

namespace MovieTest.Domain.Handlers
{
    public class AddMovieHandler : IHandleApiRequestAsync<AddMovieRequest, bool>
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
