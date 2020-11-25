using CarvedRock.Api.Data.Repositories;
using CarvedRock.Api.GraphQL.Types;
using GraphQL.Types;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockQuery: ObjectGraphType
    {
        public CarvedRockQuery(
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
