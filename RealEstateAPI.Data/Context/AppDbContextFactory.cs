using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RealEstateAPI.Data.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        // Kendi PostgreSQL şifreni yaz
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=realestate_db;Username=postgres;Password=19071907");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}