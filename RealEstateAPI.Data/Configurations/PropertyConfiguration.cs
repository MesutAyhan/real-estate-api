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
        builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(5000);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        
        // Konum bilgileri
        builder.Property(p => p.Address).IsRequired().HasMaxLength(500);
        builder.Property(p => p.City).IsRequired().HasMaxLength(100);
        builder.Property(p => p.District).HasMaxLength(100);
        
        // Fiziksel özellikler
        builder.Property(p => p.Area).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(p => p.AgentId).IsRequired();

        // İlişkiler
        
        // Property -> PropertyType (Çoka-Bir)
        builder.HasOne(p => p.PropertyType)
            .WithMany(pt => pt.Properties)
            .HasForeignKey(p => p.PropertyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Property -> Agent (Çoka-Bir)
        builder.HasOne(p => p.Agent)
            .WithMany(u => u.Properties)
            .HasForeignKey(p => p.AgentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Property -> PropertyImages 
        builder.HasMany(p => p.Images)
            .WithOne(pi => pi.Property)
            .HasForeignKey(pi => pi.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Property -> Inquiries  
        builder.HasMany(p => p.Inquiries)
            .WithOne(i => i.Property)
            .HasForeignKey(i => i.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}