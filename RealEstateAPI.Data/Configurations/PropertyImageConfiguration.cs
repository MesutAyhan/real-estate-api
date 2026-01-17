using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Configurations;

public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
{
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        builder.ToTable("PropertyImages");
        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.ImageUrl).IsRequired().HasMaxLength(1907);
        builder.Property(pi => pi.DisplayOrder).IsRequired();
        builder.Property(pi => pi.IsPrimary).IsRequired();
    }
}