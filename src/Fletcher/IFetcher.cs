using System.Collections.Generic;

namespace Fletcher
{
    public interface IFetcher
    {
        IEnumerable<TResult> All<TResult>(Fetchable fetchable);
    }
}