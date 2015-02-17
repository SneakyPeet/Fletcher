using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Fletcher.ExpressionExtraction;

namespace Fletcher.Dapper.QueryExtration
{
    public class QueryExtractor : IQueryExtractor
    {
        public FetchableQuery Extract(ExpressionTree expressionTree)
        {
            var query = new StringBuilder("Select * From "); 
            query.Append(expressionTree.Root);
            ExpandoObject param = null;
            if (expressionTree.RootNode != null)
            {
                var endNode = expressionTree.RootNode as EndNode;
                if(endNode != null)
                {
                    query.Append(" Where ");
                    query.Append(endNode.Key);
                    query.Append(" = @");
                    query.Append(endNode.Key);
                    param = new ExpandoObject();
                    ((IDictionary<string, object>)param)[endNode.Key] = endNode.Value;
                }

            }
            return new FetchableQuery(query.ToString(), param);
        }
    }
}