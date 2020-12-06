using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Sample.Domain.Entities;

namespace GraphQL.Sample.Domain.Interfaces.Repositories
{
    public interface IProductReviewRepository
    {
        Task<ProductReview> Add(ProductReview productReview);
        Task<List<ProductReview>> GetAll();
        Task<List<ProductReview>> GetByProductId(int productId);
        Task<ILookup<int, ProductReview>> GetByProductIds(IEnumerable<int> productIds);
    }
}