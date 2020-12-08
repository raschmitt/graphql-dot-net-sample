using GraphQL.Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Tests.Builders
{
    class ProductBuilder
    {
        private readonly int _id = 24;
        private readonly string _name = "Hiking Boots";
        private readonly ProductCategory _category = ProductCategory.Boots;
        private readonly string _description = "Some hicking boots";
        private readonly double _price = 75.55;

    }
}
