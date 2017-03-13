using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using MovieTest.Data.Model;

namespace MovieTest.Data.Repositories
{
    public interface IMoviesrepository : IDisposable
    {
        void Add(Movie movie);

        void Update(Movie movie);

        void Delete(Guid id);

        Movie FindById(Guid id);

        IEnumerable<Movie> GetMovies();

        void Save();
    }

    public class MoviesRepository : IMoviesrepository
    {
        private MoviesDbContext _context;

        public MoviesRepository(MoviesDbContext context)
        {
            this._context = context;
        }

        public void Add(Movie movie)
        {
            this._context.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            this._context.Entry(movie).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Movie movie = this.FindById(id);
            this._context.Movies.Remove(movie);
        }

        public Movie FindById(Guid id)
        {
            return this._context.Movies.Find(id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return this._context.Movies.ToList();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
