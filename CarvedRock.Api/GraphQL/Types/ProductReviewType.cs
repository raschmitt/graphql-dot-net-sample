using CarvedRock.Api.Data.Entities;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(pr => pr.Id);
            Field(pr => pr.Title);
            Field(pr => pr.Review);
        }
    }
}