using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Data
{
    public class AddressMap
    {
        public AddressMap(EntityTypeBuilder<Address> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.AddressLine1).IsRequired();
            entityBuilder.Property(t => t.Street).IsRequired();
            entityBuilder.Property(t => t.City).IsRequired();
            entityBuilder.Property(t => t.Postcode).IsRequired();
            entityBuilder.HasOne(e => e.Customer).WithMany(e => e.Addresses).HasForeignKey(e => e.CustomerId);
        }
    }
}

