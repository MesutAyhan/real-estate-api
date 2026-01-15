using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Context;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Veritabanı tabloları
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyType> PropertyTypes { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }
    public DbSet<Inquiry> Inquiries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Soft Delete için Global Query Filter
        modelBuilder.Entity<Property>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<PropertyType>().HasQueryFilter(pt => !pt.IsDeleted);
        modelBuilder.Entity<PropertyImage>().HasQueryFilter(pi => !pi.IsDeleted);
        modelBuilder.Entity<Inquiry>().HasQueryFilter(i => !i.IsDeleted);
        modelBuilder.Entity<AppUser>().HasQueryFilter(u => !u.IsDeleted);
    }
}