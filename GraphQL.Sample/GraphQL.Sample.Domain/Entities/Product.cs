using System.Collections.Generic;

namespace GraphQL.Sample.Domain.Entities
{
    //ToDo: utilizar setters privados
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<ProductReview> ProductReviews { get; set; }

        public Product()
        {
        }

        public Product(string name, ProductCategory category, string description, double price, List<ProductReview> productReviews)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            ProductReviews = productReviews;
        }
    }
}
