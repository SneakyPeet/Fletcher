using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Fletcher.Dapper.QueryExtration;
using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper
{
    public class DapperFetcher : IFetcher
    {
        private readonly string connectionString;
        private readonly IExpressionExtractor expressionExtractor;
        private readonly IQueryExtractor queryExtractor;

        public DapperFetcher(string connectionString, IExpressionExtractor expressionExtractor, IQueryExtractor queryExtractor)
        {
            this.connectionString = connectionString;
            this.expressionExtractor = expressionExtractor;
            this.queryExtractor = queryExtractor;
        }

        public IEnumerable<T> All<T>(Fetchable fetchable)
        {
            var fetchableQuery = ExtractQuery(fetchable);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var results = connection.Query<T>(fetchableQuery.Query, fetchableQuery.WhereParameter);
                return results;
            }
        }

        private FetchableQuery ExtractQuery(Fetchable fetchable)
        {
            var expressionTree = this.expressionExtractor.Extract(fetchable);
            return this.queryExtractor.Extract(expressionTree);
        }
    }
}
