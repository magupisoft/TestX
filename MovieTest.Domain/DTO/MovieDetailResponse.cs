using System;

namespace MovieTest.Domain.DTO
{
    public class MovieDetailResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Classification { get; set; }

        public string Duration { get; set; }

        public string Genres { get; set; }
    }
}