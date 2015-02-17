namespace Fletcher.ExpressionExtraction
{
    public interface IExpressionExtractor
    {
        ExpressionTree Extract(Fetchable fetchable);
    }
}