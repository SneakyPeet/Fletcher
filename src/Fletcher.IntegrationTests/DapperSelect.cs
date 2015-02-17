﻿using System.Linq;
using Fletcher.Dapper;
using Fletcher.IntegrationTests.TestHelpers;
using Fletcher.Language;
using NUnit.Framework;

namespace Fletcher.IntegrationTests
{
    [TestFixture]
    public class DapperSelect
    {
        private IFetcher fetcher;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            this.fetcher = DapperFetcherFactory.Make("Data Source=.;Initial Catalog=SimpleDDD;Integrated Security=True");
        }

        [Test]
        public void GivenSimleFetchable_FetchAllRows()
        {
            var fetchable = Select.From<ProductFetchable>();
            var products = this.fetcher.All<Product>(fetchable);

            Assert.AreEqual(4, products.Count());
        } 
    }
}