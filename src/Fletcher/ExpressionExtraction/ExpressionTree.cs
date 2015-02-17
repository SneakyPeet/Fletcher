namespace Fletcher.ExpressionExtraction
{
    public class ExpressionTree
    {
        public string Root { get; private set; }

        public ExpressionTree(string root)
        {
            this.Root = root;
        }
    }
}