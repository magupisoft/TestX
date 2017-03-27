using System.Collections.Generic;

using MovieTest.Common.DTO;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IGetMovieListHandler : IHandleApiRequestAsync<IEnumerable<MovieDetailResponse>>
    {
    }
}