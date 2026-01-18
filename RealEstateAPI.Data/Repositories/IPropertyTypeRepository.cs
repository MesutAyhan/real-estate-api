using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Repositories;

public interface IPropertyTypeRepository : IRepository<PropertyType>
{
    Task<PropertyType?> GetByNameAsync(string name);
}