using System;
using System.Threading.Tasks;

using AutoMapper;

using MovieTest.Common.DTO;
using MovieTest.Common.Interfaces.Handlers;
using MovieTest.Common.Interfaces.Repositories;
using MovieTest.Common.Models;

namespace MovieTest.Domain.Handlers
{
    public class AddMovieHandler : BaseHandler, IAddMovieHandler
    {
        private readonly IMoviesrepository repository;
        
        public AddMovieHandler(IMoviesrepository repository, IMapper mapper)
            : base(mapper)
        {
            this.repository = repository;
        }

        public async Task<bool> GetResponseAsync(AddMovieRequest request)
        {
            try
            {
                var movie = this.mapper.Map<Movie>(request);
                await this.repository.Add(movie);
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
