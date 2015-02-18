using System.Linq;
using Fletcher.Dapper;
using Fletcher.IntegrationTests.TestHelpers;
using Fletcher.Language;
using NUnit.Framework;

namespace Fletcher.IntegrationTests
{
    [TestFixture]
    public class DapperSelect
    {
        private IFetcher fetch;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            this.fetch = DapperFetcherFactory.Make("Data Source=.;Initial Catalog=SimpleDDD;Integrated Security=True");
        }

        [Test]
        public void GivenSimleFetchable_FetchAllRows()
        {
            var fetchable = Select.From<ProductFetchable>();
            var products = this.fetch.All<Product>(fetchable);

            Assert.AreEqual(4, products.Count());
        } 

        [Test]

        public void GivenSimpleWhere_FetchSingleRow()
        {
            var fetchable = Select.From<ProductFetchable>().Where(x => x.ProductId == 2);
            var products = this.fetch.All<Product>(fetchable);

            Assert.AreEqual(1, products.Count());
        }
    }
}