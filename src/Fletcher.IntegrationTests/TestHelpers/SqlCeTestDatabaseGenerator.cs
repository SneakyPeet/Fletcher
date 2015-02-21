﻿using System.Data.SqlServerCe;
using System.IO;

namespace Fletcher.IntegrationTests.TestHelpers
{
    public abstract class SqlCeTestDatabaseGenerator
    {
        public void SetupSqlCeTestDatabase()
        {
            this.CreateTestdatabase();
        }

        private void CreateTestdatabase()
        {
            if (File.Exists(Constants.SqlCeDatabaseFileName))
            {
                File.Delete(Constants.SqlCeDatabaseFileName);
            }
            var engine = new SqlCeEngine(Constants.SqlCeConnectionString);
            engine.CreateDatabase();
        }

        public void CreateAndPopulateProjectsTable()
        {
            using (var connection = new SqlCeConnection(Constants.SqlCeConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                ExecuteQuery(cmd, "CREATE TABLE "+ Constants.ProductsTableName + "(ProductId int PRIMARY KEY, Name nvarchar(50))");
                ExecuteQuery(cmd, "INSERT INTO " + Constants.ProductsTableName + "(ProductId, Name) VALUES (1, 'Fighter Jet')");
                ExecuteQuery(cmd, "INSERT INTO " + Constants.ProductsTableName + "(ProductId, Name) VALUES (2, 'iPod')");
                ExecuteQuery(cmd, "INSERT INTO " + Constants.ProductsTableName + "(ProductId, Name) VALUES (3, 'Wallet')");
                ExecuteQuery(cmd, "INSERT INTO " + Constants.ProductsTableName + "(ProductId, Name) VALUES (4, 'Pc')");
                connection.Close();
            }
        }

        private void ExecuteQuery(SqlCeCommand cmd, string query)
        {
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
    }
}