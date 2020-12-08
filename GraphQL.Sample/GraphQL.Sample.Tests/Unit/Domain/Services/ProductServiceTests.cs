using GraphQL.Sample.Domain.Interfaces.Repositories;
using GraphQL.Sample.Domain.Services;
using GraphQL.Sample.Tests.Builders;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GraphQL.Sample.Tests.Unit.Domain.Services
{
    public class ProductServiceTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductReviewRepository _productReviewRepository;

        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _productReviewRepository = Substitute.For<IProductReviewRepository>();

            _productService = new ProductService(_productRepository, _productReviewRepository);
        }

        [Fact]
        public async Task Should_add_a_product_review()
        {
            //Arrange
            var productReview = new ProductReviewBuilder().Build();

            //Act
            await _productService.AddProductReview(productReview);

            //Assert
            await _productReviewRepository.Received(1).Add(productReview);
        }

        [Fact]
        public async Task Should_get_all_products()
        {
            //Act
            await _productService.GetAllProducts();

            //Assert
            await _productRepository.Received(1).GetAll();
        }

        [Fact]
        public async Task Should_get_a_product_by_id()
        {
            //Arrange
            var productId = 3;

            //Act
            await _productService.GetProductById(productId);

            //Assert
            await _productRepository.Received(1).GetById(productId);
        }

        [Fact]
        public async Task Should_get_product_reviews_by_product_ids()
        {
            //Arrange
            var productIds = new List<int> { 2, 5, 9};

            //Act
            await _productService.GetProductReviewsByProductIds(productIds);

            //Assert
            await _productReviewRepository.Received(1).GetByProductIds(productIds);
        }
    }
}
