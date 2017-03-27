using System;

using MovieTest.Common.DTO;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IGetMovieHandler : IHandleApiRequestAsync<Guid, MovieDetailResponse>
    {
    }
}