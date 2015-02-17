namespace Fletcher.IntegrationTests.TestHelpers
{
    public class ProductFetchable : Fetchable<ProductFetchable, Product>
    {
        public ProductFetchable()
            : base("Products")
        {

        }
    }
}