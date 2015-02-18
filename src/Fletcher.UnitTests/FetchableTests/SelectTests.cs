using System;
using System.Collections.Generic;
using System.Dynamic;
using Fletcher.Dapper.QueryExtration;
using Fletcher.Exceptions;
using Fletcher.ExpressionExtraction;
using Fletcher.Language;
using Fletcher.UnitTests.TestHelpers;
using NUnit.Framework;

namespace Fletcher.UnitTests.FetchableTests
{
    [TestFixture]
    public class SelectTests
    {
        private IExpressionExtractor expressionExtractor;
        private IQueryExtractor queryExtractor;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            expressionExtractor = new ExpressionExtractor();
            queryExtractor = new QueryExtractor();
        }

        [Test]
        public void GivenFetchable_QueryShouldBe_SelectStarFrom()
        {
            var fetchable = Select.From<TestTable>();
            var fetchableQuery = GetQuery(fetchable);

            Assert.AreEqual("Select * From TestTable", fetchableQuery.Query);
        }

        [Test]
        [ExpectedException(typeof(InvalidWhereClauseExpressionException))]
        public void GivenUnUsableExpression_ThrowException()
        {
            var fetchable = Select.From<TestTable>().Where(x => true);
            expressionExtractor.Extract(fetchable);
        }

        [Test]
        public void GivenWhereEqualsFetchable_QueryShouldIncludeWhereClause()
        {
            var fetchable = Select.From<TestTable>().Where(x => x.Id == 1);
            var fetchableQuery = GetQuery(fetchable);

            Assert.AreEqual("Select * From TestTable Where Id = @Id", fetchableQuery.Query);
            this.AssertPropertyValue(fetchableQuery.WhereParameter, "Id", 1);
        }

        [Test]
        public void GivenWhereNotEqualsFetchable_QueryShouldIncludeWhereClause()
        {
            var fetchable = Select.From<TestTable>().Where(x => x.Id != 1);
            var fetchableQuery = GetQuery(fetchable);

            Assert.AreEqual("Select * From TestTable Where Id <> @Id", fetchableQuery.Query);
            this.AssertPropertyValue(fetchableQuery.WhereParameter, "Id", 1);
        }

        private void AssertPropertyValue(ExpandoObject obj, string propertyName, object expectedValue)
        {
            var dict = ((IDictionary<String, Object>)obj);
            var hasKey = dict.ContainsKey(propertyName);
            Assert.IsTrue(hasKey, "Does Not Contain Property " + propertyName);
            Assert.AreEqual(expectedValue, dict[propertyName]);
        }

        private FetchableQuery GetQuery(Fetchable<TestTable, ReturnTypeDto> fetchable)
        {
            var expressionTree = expressionExtractor.Extract(fetchable);
            return queryExtractor.Extract(expressionTree);
        }

        //[Test]
        //public void GivenWhereFetchable_QueryShouldBIncludeWhereClauseObject()
        //{
        //    //var fetchable = Select.From<TestTable>().Where();

        //    //Assert.AreEqual("Select * From TestTable Where Id = @Id", fetchable.Query);
        //    //Assert.IsTrue(fetchable.HasWhereClause);
        //    //Assert.IsNotNull(fetchable.QueryParameter);
        //    throw new NotImplementedException("Test Return Param");
        //}
    }
}