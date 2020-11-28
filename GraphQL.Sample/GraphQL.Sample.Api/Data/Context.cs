using GraphQL.Sample.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sample.Api.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
