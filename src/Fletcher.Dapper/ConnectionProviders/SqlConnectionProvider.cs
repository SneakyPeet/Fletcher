using System.Data.Common;
using System.Data.SqlClient;

namespace Fletcher.Dapper.ConnectionProviders
{
    public class SqlConnectionProvider : IConnectionProvider
    {
        private readonly string connectionString;

        public SqlConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection Make()
        {
            return new SqlConnection(connectionString);
        }
    }
}