using GraphQL.Sample.Api.GraphQL.Types;
using GraphQL.Sample.Domain.Interfaces.Services;
using GraphQL.Types;

namespace GraphQL.Sample.Api.GraphQL
{
    public class Query: ObjectGraphType
    {
        public Query(IProductService productService)
        {
            Field<ListGraphType<ProductType>>(
                "products", 
                resolve: context => productService.GetAllProducts()
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
                    return productService.GetProductById(id);
                }
            );
        }
    }
}
