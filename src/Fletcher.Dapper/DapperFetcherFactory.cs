using Fletcher.Dapper.ConnectionProviders;
using Fletcher.Dapper.QueryExtration;
using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper
{
    public class DapperFetcherFactory
    {
        public static IFetcher Make(IConnectionProvider connectionProvider)
        {

            return new DapperFetcher(new ExpressionExtractor(), new QueryExtractor(), connectionProvider);
        }
    }
}
