using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Sample.Domain.Entities;

namespace GraphQL.Sample.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductReview> AddProductReview(ProductReview productReview);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<ILookup<int, ProductReview>> GetProductReviewsByProductIds(IEnumerable<int> productIds);
    }
}