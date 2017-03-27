using System;
using System.Threading.Tasks;

using MovieTest.Common.Interfaces.Handlers;
using MovieTest.Common.Interfaces.Repositories;

namespace MovieTest.Domain.Handlers
{
    public class RemoveMovieHandler : IRemoveMovieHandler
    {
        private readonly IMoviesrepository repository;

        public RemoveMovieHandler(IMoviesrepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> GetResponseAsync(Guid request)
        {
            try
            {
                await this.repository.Delete(request);
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
