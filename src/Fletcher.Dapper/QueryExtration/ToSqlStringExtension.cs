using System.Linq.Expressions;
using Fletcher.Dapper.Exceptions;

namespace Fletcher.Dapper.QueryExtration
{
    public static class ToSqlStringExtension
    {
        public static string ToSqlString(this ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "<>";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                default:
                    throw new NotValidSqlExpressionTypeException();

            }
        }
    }
}