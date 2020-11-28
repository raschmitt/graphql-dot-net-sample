using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Sample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sample.Api.Data.Repositories
{
    public class ProductRepository
    {
        private readonly Context _dbContext;

        public ProductRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Product>> GetAll()
        {
            return _dbContext.Products.ToListAsync();
        }
        
        public Task<Product> GetById(int id)
        {
            return _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
