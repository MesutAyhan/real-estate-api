using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Core.Entities;
using RealEstateAPI.Data.Context;

namespace RealEstateAPI.Data.Repositories;

public class InquiryRepository : Repository<Inquiry>, IInquiryRepository
{
    public InquiryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Inquiry>> GetInquiriesByPropertyAsync(int propertyId)
    {
        return await _dbSet
            .Include(i => i.User)
            .Where(i => i.PropertyId == propertyId)
            .OrderByDescending(i => i.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Inquiry>> GetInquiriesByAgentAsync(string agentId)
    {
        return await _dbSet
            .Include(i => i.Property)
            .Include(i => i.User)
            .Where(i => i.Property.AgentId == agentId)
            .OrderByDescending(i => i.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }
}