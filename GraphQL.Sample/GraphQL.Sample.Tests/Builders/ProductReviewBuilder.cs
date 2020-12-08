using GraphQL.Sample.Domain.Entities;

namespace GraphQL.Sample.Tests.Builders
{
    class ProductReviewBuilder
    {
        private int _productId = 5;
        private string _title = "Best product ever";
        private string _review = "I just love it";

        public ProductReview Build()
        {
            return new ProductReview(_productId, _title, _review);
        }

        public ProductReviewBuilder WithProductId(int value)
        {
            _productId = value;
            return this;
        }
    }
}
