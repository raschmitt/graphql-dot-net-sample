using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Sample.Domain.Entities;
using GraphQL.Sample.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sample.Infra.Data.Data.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
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
        
        public async Task<List<ProductReview>> GetAll()
        {
            return await _dbContext.ProductReviews.ToListAsync();
        }
        
        public async Task<List<ProductReview>> GetByProductId(int productId)
        {
            return await _dbContext.ProductReviews.Where(pr => pr.ProductId == productId).ToListAsync();
        }    
        
        public async Task<ILookup<int, ProductReview>> GetByProductIds(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.ProductReviews.Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();

            return reviews.ToLookup(pr => pr.ProductId);
        }
    }
}
