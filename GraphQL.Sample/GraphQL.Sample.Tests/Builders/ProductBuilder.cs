using GraphQL.Sample.Domain.Entities;
using System.Collections.Generic;

namespace GraphQL.Sample.Tests.Builders
{
    class ProductBuilder
    {
        private readonly string _name = "Hiking Boots";
        private readonly ProductCategory _category = ProductCategory.Boots;
        private readonly string _description = "Some hicking boots";
        private readonly double _price = 75.55;
        private List<ProductReview> _productReviews;

        public Product Build()
        {
            return new Product(_name, _category, _description, _price, _productReviews);
        }
    }
}
