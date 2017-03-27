using System;

namespace MovieTest.Common.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Classification { get; set; }

        public string Duration { get; set; }

        public string Genres { get; set; }
    }
}
