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
        builder.Property(i => i.Email).IsRequired().HasMaxLength(255);
        builder.Property(i => i.Phone).HasMaxLength(20);
        builder.Property(i => i.Message).IsRequired().HasMaxLength(1000);
        builder.Property(i => i.Status).IsRequired();

        // User silindiğinde UserId null olsun (kayıtsız kullanıcı gibi)
        builder.HasOne(i => i.User)
            .WithMany(u => u.Inquiries)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexler
        builder.HasIndex(i => i.PropertyId);
        builder.HasIndex(i => i.Status);
    }
}