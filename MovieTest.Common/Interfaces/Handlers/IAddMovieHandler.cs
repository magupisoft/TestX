using MovieTest.Common.DTO;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IAddMovieHandler : IHandleApiRequestAsync<AddMovieRequest, bool>
    {
    }
}