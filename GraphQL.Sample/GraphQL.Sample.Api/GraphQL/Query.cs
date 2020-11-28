using GraphQL.Sample.Api.Data.Repositories;
using GraphQL.Sample.Api.GraphQL.Types;
using GraphQL.Types;

namespace GraphQL.Sample.Api.GraphQL
{
    public class Query: ObjectGraphType
    {
        public Query(
            ProductRepository productRepository,
            ProductReviewRepository productReviewRepository
            )
        {
            Field<ListGraphType<ProductType>>(
                "products", 
                resolve: context => productRepository.GetAll()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetById(id);
                }
            );
            
            Field<ListGraphType<ProductReviewType>>(
                "productReviews", 
                resolve: context => productReviewRepository.GetAll()
            );
        }
    }
}
