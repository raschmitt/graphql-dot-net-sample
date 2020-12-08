using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Entities;
using GraphQL.Sample.Domain.Interfaces.Services;
using GraphQL.Types;

namespace GraphQL.Sample.Api.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(
            IProductService productService,
            IDataLoaderContextAccessor dataLoaderContextAccessor
            )
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the product");
            Field(t => t.Description).Description("The description of the product");
            Field(t => t.Price).Description("The unitary price of the product");
            Field<ProductCategoryType>("Category", "The category of the product");

            Field<ListGraphType<ProductReviewType>>(
                "reviews", 
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetByProductId", productService.GetProductReviewsByProductIds);
            
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
