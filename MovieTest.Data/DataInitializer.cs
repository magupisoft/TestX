using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

using MovieTest.Data.Migrations;

namespace MovieTest.Data
{
    public class DataInitializer
    {
        public static void Initialize(string connectionString)
        {
            var configuration = new MoviesDbConfiguration
                                    {
                                        TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient")
                                    };

            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}
