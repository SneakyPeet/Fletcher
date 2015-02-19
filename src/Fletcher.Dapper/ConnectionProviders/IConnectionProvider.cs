using System.Data.Common;

namespace Fletcher.Dapper.ConnectionProviders
{
    public interface IConnectionProvider
    {
        DbConnection Make();
    }
}