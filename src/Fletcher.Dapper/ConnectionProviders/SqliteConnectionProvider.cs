using System.Data.Common;
using Mono.Data.Sqlite;

namespace Fletcher.Dapper.ConnectionProviders
{
    public class SqliteConnectionProvider : IConnectionProvider
    {
        private readonly string connectionString;

        public SqliteConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection Make()
        {
            return new SqliteConnection(connectionString);
        }
    }
}