using GraphQL.Sample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Sample.Infra.Data.Data.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .IsRequired();
            
            builder
                .Property(i => i.Name)
                .IsRequired();
            
            builder
                .Property(i => i.Price)
                .IsRequired();
            
            builder
                .Property(i => i.Active)
                .IsRequired();
        }
    }
}