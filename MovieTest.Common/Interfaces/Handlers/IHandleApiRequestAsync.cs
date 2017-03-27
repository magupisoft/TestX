using System.Threading.Tasks;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IHandleApiRequestAsync<in T, TResult>
    {
        Task<TResult> GetResponseAsync(T request);
    }
}