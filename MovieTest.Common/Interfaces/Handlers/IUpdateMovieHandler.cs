using MovieTest.Common.DTO;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IUpdateMovieHandler : IHandleApiRequestAsync<UpdateMovieRequest, bool>
    {
    }
}