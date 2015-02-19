using System.Data.Common;
using System.Data.SqlServerCe;

namespace Fletcher.Dapper.ConnectionProviders
{
    public class SqlCeConnectionProvider : IConnectionProvider
    {
        private readonly string connectionString;

        public SqlCeConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection Make()
        {
            return new SqlCeConnection(connectionString);
        }
    }
}