
namespace Fletcher.ExpressionExtraction
{
    public class ExpressionExtractor : IExpressionExtractor
    {
        public ExpressionTree Extract(Fetchable fetchable)
        {
            return new ExpressionTree(fetchable.Container);
        }
    }
}