using Fletcher.Dapper.QueryExtration;
using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper
{
    public class DapperFetcherFactory
    {
        public static IFetcher Make(string connectionString)
        {
            return new DapperFetcher(connectionString, new ExpressionExtractor(), new QueryExtractor());
        }
    }
}
