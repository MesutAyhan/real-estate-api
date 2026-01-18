using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Core.Entities;
using RealEstateAPI.Data.Context;

namespace RealEstateAPI.Data.Repositories;

public class PropertyTypeRepository : Repository<PropertyType>, IPropertyTypeRepository
{
    public PropertyTypeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PropertyType?> GetByNameAsync(string name)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(pt => pt.Name == name);
    }
}