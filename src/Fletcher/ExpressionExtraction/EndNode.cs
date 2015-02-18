using System.Linq.Expressions;
using Fletcher.Exceptions;

namespace Fletcher.ExpressionExtraction
{
    public class EndNode : ExpressionNode
    {
        public string Key { get; private set; }
        public object Value { get; private set; }
        public ExpressionType Comparitor { get; private set; }

        public EndNode(BinaryExpression expression)
        {
            this.GetKey(expression);
            this.GetValue(expression);
            this.GetComparitor(expression);
        }

        private void GetValue(BinaryExpression expression)
        {
            var right = expression.Right as ConstantExpression;
            Guard.AgainstNullExpression(right);
            this.Value = right.Value;
        }

        private void GetKey(BinaryExpression expression)
        {
            var left = expression.Left as MemberExpression;
            Guard.AgainstNullExpression(left);
            this.Key = left.Member.Name;
        }

        private void GetComparitor(BinaryExpression expression)
        {
            this.Comparitor = expression.NodeType;
        }

        
    }
}