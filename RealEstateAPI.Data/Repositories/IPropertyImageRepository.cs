using RealEstateAPI.Core.Entities;

namespace RealEstateAPI.Data.Repositories;

public interface IPropertyImageRepository : IRepository<PropertyImage>
{
    Task<IEnumerable<PropertyImage>> GetImagesByPropertyAsync(int propertyId);
    Task<PropertyImage?> GetPrimaryImageAsync(int propertyId);
}