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
}