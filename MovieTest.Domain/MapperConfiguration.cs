using AutoMapper;
using AutoMapper.Configuration;

using MovieTest.Data.Model;
using MovieTest.Domain.Models;

namespace MovieTest.Domain
{
    public class MapperConfiguration
    {
        public static void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Movie, AddMovieRequest>();
            Mapper.Initialize(cfg);
        }
    }
}
