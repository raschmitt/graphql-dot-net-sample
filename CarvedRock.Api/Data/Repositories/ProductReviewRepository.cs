using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Data.Repositories
{
    public class ProductReviewRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
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
            var reviews = await _dbContext.ProductReviews.Where(pr => productIds.Contains(pr.Id)).ToListAsync();

            return reviews.ToLookup(pr => pr.ProductId);
        }
    }
}
