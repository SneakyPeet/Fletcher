using System;
using Fletcher.Dapper.QueryExtration;
using Fletcher.ExpressionExtraction;
using Fletcher.Language;
using Fletcher.UnitTests.TestHelpers;
using NUnit.Framework;

namespace Fletcher.UnitTests.FetchableTests
{
    [TestFixture]
    public class SelectTests
    {
        [Test]
        public void GivenFetchable_QueryShouldBe_SelectStarFrom()
        {
            var fetchable = Select.From<TestTable>();
            var expressionTree = new ExpressionExtractor().Extract(fetchable);
            var fetchableQuery = new QueryExtractor().Extract(expressionTree);

            Assert.AreEqual("Select * From TestTable", fetchableQuery.Query);
        }

        //[Test]
        //public void GivenWhereFetchable_QueryShouldIncludeWhereClause()
        //{
        //    var fetchable = Select.From<TestTable>().Where(x => x.Id == 1);

        //    Assert.AreEqual("Select * From TestTable Where Id = @Id", fetchable.Query);
        //    Assert.IsTrue(fetchable.HasWhereClause);
        //}

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