using System;
using System.Threading.Tasks;

using MovieTest.Data.Repositories;

namespace MovieTest.Domain.Handlers
{
    public interface IRemoveMovieHandler : IHandleApiRequestAsync<Guid, bool>
    {
    }

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
