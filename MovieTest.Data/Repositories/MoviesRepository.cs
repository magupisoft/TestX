using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using MovieTest.Common.Interfaces.Repositories;
using MovieTest.Common.Models;
using MovieTest.Data.EF;

namespace MovieTest.Data.Repositories
{
    public class MoviesRepository : IMoviesrepository
    {
        private readonly MoviesDbContext context;

        public MoviesRepository(MoviesDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Movie movie)
        {
            this.context.Movies.Add(movie);
        }

        public async Task Update(Movie movie)
        {
            this.context.Entry(movie).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            var movie = await this.GetByUnique(id);
            this.context.Movies.Remove(movie);
        }

        public async Task<Movie> GetByUnique(Guid id)
        {
            return await this.context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return this.context.Movies.ToList();
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
