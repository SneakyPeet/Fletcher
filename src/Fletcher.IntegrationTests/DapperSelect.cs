using System.Linq;
using Fletcher.Dapper;
using Fletcher.Dapper.ConnectionProviders;
using Fletcher.IntegrationTests.TestHelpers;
using Fletcher.Language;
using NUnit.Framework;

namespace Fletcher.IntegrationTests
{
    [TestFixture]
    public class DapperSelect : SqlCeTestDatabaseGenerator
    {
        private IFetcher fetch;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            SetupSqlCeTestDatabase();
            CreateAndPopulateProjectsTable();
            this.fetch = DapperFetcherFactory.Make(new SqliteConnectionProvider(Constants.SqlCeConnectionString));
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
            var products = this.fetch.All<Product>(fetchable).ToList();

            Assert.AreEqual(1, products.Count());
            Assert.AreEqual("iPod", products.First().Name);
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