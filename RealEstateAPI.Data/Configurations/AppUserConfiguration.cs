using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.ProfilePicture).HasMaxLength(1000);
        builder.Property(u => u.AgencyName).HasMaxLength(200);
        builder.Property(u => u.LicenseNumber).HasMaxLength(50);

        // Email ve IsAgent'a göre sık arama yapılacağı için index
        builder.HasIndex(u => u.Email);
        builder.HasIndex(u => u.IsAgent);
    }
}