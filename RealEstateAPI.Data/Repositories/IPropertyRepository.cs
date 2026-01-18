using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Repositories;

/// <summary>
/// Property entity için özel repository interface
/// </summary>
public interface IPropertyRepository : IRepository<Property>
{
    // Özel metodlar
    Task<IEnumerable<Property>> GetPropertiesWithDetailsAsync();
    Task<Property?> GetPropertyWithDetailsAsync(int id);
    Task<IEnumerable<Property>> GetPropertiesByAgentAsync(string agentId);
    Task<IEnumerable<Property>> GetPropertiesByCityAsync(string city);
}