using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Sample.Domain.Entities;

namespace GraphQL.Sample.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
    }
}