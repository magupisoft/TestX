using System.Threading.Tasks;

namespace MovieTest.Domain.Handlers
{
    public interface IHandleApiRequestAsync<in T, TResult>
    {
        Task<TResult> GetResponseAsync(T request);
    }

    public interface IHandleApiRequestAsync<T>
    {
        Task<T> GetResponseAsync();
    }
}
