using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper.QueryExtration
{
    public class QueryExtractor : IQueryExtractor
    {
        public FetchableQuery Extract(ExpressionTree fetchable)
        {
            var query = "Select * From " + fetchable.Root;
            return new FetchableQuery(query);
        }
    }
}