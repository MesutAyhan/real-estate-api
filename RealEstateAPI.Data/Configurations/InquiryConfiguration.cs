using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Configurations;

public class InquiryConfiguration : IEntityTypeConfiguration<Inquiry>
{
    public void Configure(EntityTypeBuilder<Inquiry> builder)
    {
        builder.ToTable("Inquiries");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
        builder.Property(i => i.Email).IsRequired().HasMaxLength(100);
        builder.Property(i => i.Phone).HasMaxLength(20);
        builder.Property(i => i.Message).IsRequired().HasMaxLength(1000);
        builder.Property(i => i.Status).IsRequired();
    }
}