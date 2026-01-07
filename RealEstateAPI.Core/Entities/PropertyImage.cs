namespace RealEstateAPI.Core.Entities;

public class PropertyImage : BaseEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; } = false;
    
    // Foreign Key
    public int PropertyId { get; set; }
    
    // Navigation Property
    public Property Property { get; set; } = null!;
}