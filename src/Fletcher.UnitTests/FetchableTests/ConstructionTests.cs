using Fletcher.Language;
using Fletcher.Exceptions;
using Fletcher.UnitTests.TestHelpers;
using NUnit.Framework;

namespace Fletcher.UnitTests.FetchableTests
{
    public class ConstructionTests
    {
        [Test]
        public void GivenFetchable_QueryShouldNotBe_Null()
        {
            var fetchable = Select.From<TestTable>();

            Assert.IsNotNull(fetchable);
        }

        [Test]
        public void GivenFetchable_QueryShouldBe_CorrectType()
        {
            var fetchable = Select.From<TestTable>();

            Assert.AreEqual(typeof(TestTable), fetchable.GetType());
        }

        [Test]
        [ExpectedException(typeof(FetchableContainerEmptyException))]
        public void GivenFetchable_WithNullOrEmptyContainer_ThrowException()
        {
            Select.From<EmptyContainerTestTable>();
        }

        [Test]
        public void GivenFetchable_WithoutWhere_WhereClauseShouldBeNull()
        {
            var fetchable = Select.From<TestTable>();
            Assert.IsFalse(fetchable.HasWhereClause);
            Assert.IsNull(fetchable.WhereClause);
        }

        [Test]
        public void GivenFetchable_WithWhere_WhereClauseShouldNotBe()
        {
            var fetchable = Select.From<TestTable>().Where(x => x.Id == 5);
            Assert.IsTrue(fetchable.HasWhereClause);
            Assert.IsNotNull(fetchable.WhereClause);
        }
    }
}