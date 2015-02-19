using System.Collections.Generic;
using Dapper;
using Fletcher.Dapper.ConnectionProviders;
using Fletcher.Dapper.QueryExtration;
using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper
{
    public class DapperFetcher : IFetcher
    {
        private readonly IExpressionExtractor expressionExtractor;
        private readonly IQueryExtractor queryExtractor;
        private readonly IConnectionProvider connectionProvider;

        public DapperFetcher(IExpressionExtractor expressionExtractor, IQueryExtractor queryExtractor, IConnectionProvider connectionProvider)
        {
            this.expressionExtractor = expressionExtractor;
            this.queryExtractor = queryExtractor;
            this.connectionProvider = connectionProvider;
        }

        public IEnumerable<T> All<T>(Fetchable fetchable)
        {
            var fetchableQuery = ExtractQuery(fetchable);
            using (var connection = connectionProvider.Make())
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
