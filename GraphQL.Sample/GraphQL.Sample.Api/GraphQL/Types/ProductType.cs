using GraphQL.DataLoader;
using GraphQL.Sample.Domain.Entities;
using GraphQL.Sample.Domain.Services;
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
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            
            Field<ProductTypeEnumType>("Type", "The type of product");
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
