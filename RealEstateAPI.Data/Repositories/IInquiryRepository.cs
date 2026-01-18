using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Repositories;

public interface IInquiryRepository : IRepository<Inquiry>
{
    Task<IEnumerable<Inquiry>> GetInquiriesByPropertyAsync(int propertyId);
    Task<IEnumerable<Inquiry>> GetInquiriesByAgentAsync(string agentId);
}