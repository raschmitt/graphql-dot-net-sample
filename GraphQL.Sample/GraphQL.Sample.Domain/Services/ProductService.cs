using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Sample.Domain.Entities;
using GraphQL.Sample.Domain.Interfaces.Repositories;
using GraphQL.Sample.Domain.Interfaces.Services;

namespace GraphQL.Sample.Domain.Services
{
    //ToDo: Retornar DTOs e não entidades concretas
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductReviewRepository _productReviewRepository;
        
        public ProductService(
            IProductRepository productRepository, 
            IProductReviewRepository productReviewRepository)
        {
            _productRepository = productRepository;
            _productReviewRepository = productReviewRepository;
        }
        
        public async Task<ProductReview> AddProductReview(ProductReview productReview)
        {
            return await _productReviewRepository.Add(productReview);
        }
        
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetById(productId);
        }
        
        public async Task<ILookup<int, ProductReview>> GetProductReviewsByProductIds(IEnumerable<int> productIds)
        {
            return await _productReviewRepository.GetByProductIds(productIds);
        }
    }
}