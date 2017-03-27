using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace MovieTest.Data.EF
{
    public class DatabaseConfiguration : DbConfiguration 
    {
        public DatabaseConfiguration() 
        {
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        } 
    }
}
