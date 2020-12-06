using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Sample.Domain.Entities;
using GraphQL.Sample.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sample.Infra.Data.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _dbContext;

        public ProductRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
        
        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
