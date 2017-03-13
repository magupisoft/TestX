using AutoMapper;
using AutoMapper.Configuration;

using MovieTest.Data.Models;
using MovieTest.Domain.DTO;

namespace MovieTest.Domain
{
    public class MapperConfiguration
    {
        public static void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Movie, AddMovieRequest>();
            cfg.CreateMap<Movie, UpdateMovieRequest>();
            Mapper.Initialize(cfg);
        }
    }
}
