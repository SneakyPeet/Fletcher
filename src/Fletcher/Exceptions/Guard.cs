using System.Linq.Expressions;

namespace Fletcher.Exceptions
{
    public class Guard
    {
         public static void AgainstNullExpression(Expression expression)
         {
             if(expression == null)
             {
                 throw new InvalidWhereClauseExpressionException();
             }
         }
    }
}