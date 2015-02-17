using System.Collections.Generic;

namespace Fletcher.ExpressionExtraction
{
    public class ExpressionTree
    {
        public string Root { get; private set; }
        public ExpressionNode RootNode { get; private set; }

        public ExpressionTree(string root, EndNode endNode)
        {
            this.Root = root;
            this.RootNode = endNode;
        }

        public ExpressionTree(string root)
        {
            this.Root = root;
        }
    }
}