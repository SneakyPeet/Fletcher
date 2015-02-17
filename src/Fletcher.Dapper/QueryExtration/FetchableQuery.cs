using System.Dynamic;

namespace Fletcher.Dapper.QueryExtration
{
    public class FetchableQuery
    {
        public FetchableQuery(string query, ExpandoObject parameters)
        {
            this.Query = query;
            this.WhereParameter = parameters;
        }

        public string Query { get; private set; }
        public ExpandoObject WhereParameter { get; private set; }
    }
}