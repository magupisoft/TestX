using System;

namespace MovieTest.Data.Models
{
    // ToDo: To be implemented
    public class MovieImages
    {
        public int Id { get; set; }

        public Guid MovieId { get; set; }

        public byte[] ImageData { get; set; }
    }
}
