using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Core.Entities;
using RealEstateAPI.Data.Context;

namespace RealEstateAPI.Data.Repositories;

public class PropertyRepository : Repository<Property>, IPropertyRepository
{
    public PropertyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Property>> GetPropertiesWithDetailsAsync()
    {
        return await _dbSet
            .Include(p => p.PropertyType)
            .Include(p => p.Agent)
            .Include(p => p.Images)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Property?> GetPropertyWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(p => p.PropertyType)
            .Include(p => p.Agent)
            .Include(p => p.Images)
            .Include(p => p.Inquiries)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Property>> GetPropertiesByAgentAsync(string agentId)
    {
        return await _dbSet
            .Include(p => p.PropertyType)
            .Include(p => p.Images)
            .Where(p => p.AgentId == agentId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Property>> GetPropertiesByCityAsync(string city)
    {
        return await _dbSet
            .Include(p => p.PropertyType)
            .Include(p => p.Images)
            .Where(p => p.City == city)
            .AsNoTracking()
            .ToListAsync();
    }
}