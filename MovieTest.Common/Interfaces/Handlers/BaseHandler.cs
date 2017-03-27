using AutoMapper;

namespace MovieTest.Common.Interfaces.Handlers
{
    public abstract class BaseHandler
    {
        public readonly IMapper mapper;

        protected BaseHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
