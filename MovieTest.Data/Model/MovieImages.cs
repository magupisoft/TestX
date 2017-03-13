using System;

namespace MovieTest.Data.Model
{
    // ToDo: To be implemented
    public class MovieImages
    {
        public int Id { get; set; }

        public Guid MovieId { get; set; }

        public byte[] ImageData { get; set; }
    }
}
