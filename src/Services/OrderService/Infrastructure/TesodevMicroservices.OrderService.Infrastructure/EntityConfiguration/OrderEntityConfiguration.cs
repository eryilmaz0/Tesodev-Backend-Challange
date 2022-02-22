using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesodevMicroservices.OrderService.Domain.Entity;

namespace TesodevMicroservices.OrderService.Infrastructure.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

            //Owned Entities
            builder.OwnsOne(x => x.Address).Property(x => x.AddressLine).HasColumnName("AddressLine");
            builder.OwnsOne(x => x.Address).Property(x => x.City).HasColumnName("City").IsRequired();
            builder.OwnsOne(x => x.Address).Property(x => x.Country).HasColumnName("Country").IsRequired();
            builder.OwnsOne(x => x.Address).Property(x => x.CityCode).HasColumnName("CityCode").IsRequired();

            builder.OwnsOne(x => x.Product).Property(x => x.Id).HasColumnName("ProductId").IsRequired();
            builder.OwnsOne(x => x.Product).Property(x => x.ImageUrl).HasColumnName("ProductImageUrl").IsRequired();
            builder.OwnsOne(x => x.Product).Property(x => x.Name).HasColumnName("ProductName").IsRequired();

        }
    }
}