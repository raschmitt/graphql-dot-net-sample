using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Sample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sample.Api.Data.Repositories
{
    public class ProductReviewRepository
    {
        private readonly Context _dbContext;

        public ProductReviewRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductReview> Add(ProductReview productReview)
        {
            await _dbContext.ProductReviews.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();

            return productReview;
        }
        
        public Task<List<ProductReview>> GetAll()
        {
            return _dbContext.ProductReviews.ToListAsync();
        }
        
        public Task<List<ProductReview>> GetByProductId(int productId)
        {
            return _dbContext.ProductReviews.Where(pr => pr.ProductId == productId).ToListAsync();
        }    
        
        public async Task<ILookup<int, ProductReview>> GetByProductIds(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.ProductReviews.Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();

            return reviews.ToLookup(pr => pr.ProductId);
        }
    }
}
