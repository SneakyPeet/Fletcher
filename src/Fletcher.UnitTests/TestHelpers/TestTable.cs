namespace Fletcher.UnitTests.TestHelpers
{
    public class TestTable : Fetchable<TestTable, ReturnTypeDto>
    {
        public TestTable()
            : base("TestTable")
        {

        }
    }
}