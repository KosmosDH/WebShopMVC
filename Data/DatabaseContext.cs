using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace WebShopMVC.Data
{
    public class DatabaseContext : IDatabaseContext
    {
        private const string CONNECTION_STRING_ID = "Default";

        private readonly string _connectionString;

        public DatabaseContext(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString(CONNECTION_STRING_ID);

            if (connectionString == null)
                throw new MissingFieldException($"Failed to get access to '{CONNECTION_STRING_ID}' connection string");

            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
