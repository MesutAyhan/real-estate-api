using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable("Properties");
        builder.HasKey(p => p.Id);

        // Temel bilgiler
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(1907);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        
        // Konum bilgileri
        builder.Property(p => p.Address).IsRequired().HasMaxLength(1907);
        builder.Property(p => p.City).IsRequired().HasMaxLength(100);
        builder.Property(p => p.District).HasMaxLength(100);
        
        // Fiziksel özellikler
        builder.Property(p => p.Area).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(p => p.AgentId).IsRequired();
    }
}