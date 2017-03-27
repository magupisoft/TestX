using System;

namespace MovieTest.Common.Interfaces.Handlers
{
    public interface IRemoveMovieHandler : IHandleApiRequestAsync<Guid, bool>
    {
    }
}