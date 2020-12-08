using System.Collections.Generic;

namespace GraphQL.Sample.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<ProductReview> ProductReviews { get; set; }
    }
}
