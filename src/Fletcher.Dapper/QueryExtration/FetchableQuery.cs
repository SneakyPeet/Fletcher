namespace Fletcher.Dapper.QueryExtration
{
    public class FetchableQuery
    {
        public FetchableQuery(string query)
        {
            this.Query = query;
        }

        public string Query { get; private set; }
        public object WhereParameter { get; private set; }
    }
}