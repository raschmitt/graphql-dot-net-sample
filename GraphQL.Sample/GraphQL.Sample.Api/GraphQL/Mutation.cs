using GraphQL.Sample.Api.Data.Entities;
using GraphQL.Sample.Api.Data.Repositories;
using GraphQL.Sample.Api.GraphQL.Types;
using GraphQL.Types;

namespace GraphQL.Sample.Api.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(ProductReviewRepository productReviewRepository)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    return await productReviewRepository.Add(review);
                }
            );
        }
    }
}