using System.Threading.Tasks;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IHandleApiRequestAsync<T>
    {
        Task<T> GetResponseAsync();
    }
}
