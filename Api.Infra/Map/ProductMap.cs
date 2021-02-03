using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true);
            builder.Property(x => x.UnitValue).HasDefaultValue(0.00).IsRequired(true);
            builder.Property(x => x.DeliveryDate).IsRequired(true);
        }
    }
}