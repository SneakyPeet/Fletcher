using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper.QueryExtration
{
    public interface IQueryExtractor
    {
        FetchableQuery Extract(ExpressionTree fetchable);
    }
}