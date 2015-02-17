
using System.Linq.Expressions;
using Fletcher.Exceptions;

namespace Fletcher.ExpressionExtraction
{
    public class ExpressionExtractor : IExpressionExtractor
    {
        public ExpressionTree Extract(Fetchable fetchable)
        {
            if(fetchable.HasWhereClause)
            {
                var binaryExpression = fetchable.WhereClause.Body as BinaryExpression;
                Guard.AgainstNullExpression(binaryExpression);
                return new ExpressionTree(fetchable.Container, new EndNode(binaryExpression));
            }
            return new ExpressionTree(fetchable.Container);
        }
    }
}