using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Configurations;

public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
{
    public void Configure(EntityTypeBuilder<PropertyType> builder)
    {
        builder.ToTable("PropertyTypes");
        builder.HasKey(pt => pt.Id);

        builder.Property(pt => pt.Name).IsRequired().HasMaxLength(100);
        builder.Property(pt => pt.Description).HasMaxLength(500);
    }
}