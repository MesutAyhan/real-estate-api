using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Core.Entities;
using RealEstateAPI.Data.Context;

namespace RealEstateAPI.Data.Repositories;

public class PropertyImageRepository : Repository<PropertyImage>, IPropertyImageRepository
{
    public PropertyImageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PropertyImage>> GetImagesByPropertyAsync(int propertyId)
    {
        return await _dbSet
            .Where(pi => pi.PropertyId == propertyId)
            .OrderBy(pi => pi.DisplayOrder)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PropertyImage?> GetPrimaryImageAsync(int propertyId)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(pi => pi.PropertyId == propertyId && pi.IsPrimary);
    }
}