using GraphQL.Sample.Api.GraphQL.Types;
using GraphQL.Sample.Domain.Entities;
using GraphQL.Sample.Domain.Services;
using GraphQL.Types;

namespace GraphQL.Sample.Api.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(IProductService productService)
        {
            FieldAsync<ProductReviewType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    return await productService.AddProductReview(review);
                }
            );
        }
    }
}