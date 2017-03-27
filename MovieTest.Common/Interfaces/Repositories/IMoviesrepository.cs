using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MovieTest.Common.Models;

namespace MovieTest.Common.Interfaces.Repositories
{
    public interface IMoviesrepository : IRepository<Movie>
    {
        Task Add(Movie movie);

        Task Update(Movie movie);

        Task Delete(Guid id);

        Task<Movie> GetByUnique(Guid id);
        
        Task<IEnumerable<Movie>> GetMovies();

        Task SaveAsync();
    }
}