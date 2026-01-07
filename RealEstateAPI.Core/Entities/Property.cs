using RealEstateAPI.Core.Enums;

namespace RealEstateAPI.Core.Entities;

public class Property : BaseEntity
{
    // Temel Bilgiler
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public PropertyStatus Status { get; set; } = PropertyStatus.Available;
    
    // Konum Bilgileri
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? District { get; set; }
    
    // Fiziksel Özellikler
    public int Rooms { get; set; }
    public int? Bathrooms { get; set; }
    public decimal Area { get; set; }
    public int Floor { get; set; }
    public int? TotalFloors { get; set; }
    public int YearBuilt { get; set; }
    
    // Foreign Keys
    public int PropertyTypeId { get; set; }
    public string AgentId { get; set; } = string.Empty;
    
    // Navigation Properties
    public PropertyType PropertyType { get; set; } = null!;
    public AppUser Agent { get; set; } = null!;
    public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
    public ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
}