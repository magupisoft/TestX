using MovieTest.Data;

namespace MovieTest.Domain
{
    public class DomainInitializer
    {
        public static void Initialize(string connectionString)
        {
            DataInitializer.Initialize(connectionString);
        }
    }
}
