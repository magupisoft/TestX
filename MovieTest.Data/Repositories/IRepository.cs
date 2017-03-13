using System;
using System.Threading.Tasks;

namespace MovieTest.Data.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        Task Add(T movie);

        Task Update(T movie);

        Task Delete(Guid id);

        Task<T> GetByUnique(Guid id);
    }
}
