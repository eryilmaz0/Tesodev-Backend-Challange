using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesodevMicroservices.CustomerService.Entities.Entity;

namespace TesodevMicroservices.CustomerService.Entities.EntityConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

            //Owned Entity
            builder.OwnsOne(x => x.Address).Property(x => x.AddressLine).HasColumnName("AddressLine");
            builder.OwnsOne(x => x.Address).Property(x => x.City).HasColumnName("City").IsRequired();
            builder.OwnsOne(x => x.Address).Property(x => x.Country).HasColumnName("Country").IsRequired();
            builder.OwnsOne(x => x.Address).Property(x => x.CityCode).HasColumnName("CityCode").IsRequired();
        }
    }
}