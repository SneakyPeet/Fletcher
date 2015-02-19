using System.Linq;
using Fletcher.Dapper;
using Fletcher.Dapper.ConnectionProviders;
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
            const string connectionString = "Data Source=.;Initial Catalog=SimpleDDD;Integrated Security=True";
            this.fetch = DapperFetcherFactory.Make(new SqlConnectionProvider(connectionString));
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

        [Test]
        public void GivenGreaterThanWhere_FetchAllMatchingRows()
        {
            var fetchable = Select.From<ProductFetchable>().Where(x => x.ProductId >= 3);
            var products = this.fetch.All<Product>(fetchable);

            Assert.AreEqual(2, products.Count());
        }
    }
}