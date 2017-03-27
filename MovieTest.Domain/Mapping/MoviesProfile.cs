using AutoMapper;

using MovieTest.Common.DTO;
using MovieTest.Common.Models;

namespace MovieTest.Domain.Mapping
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            this.CreateMap<Movie, AddMovieRequest>().ReverseMap();
            this.CreateMap<Movie, UpdateMovieRequest>().ReverseMap();
            this.CreateMap<Movie, MovieDetailResponse>().ReverseMap();
        }
    }
}
