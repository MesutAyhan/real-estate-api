namespace RealEstateAPI.Core.Entities;

/// <summary>
/// Emlak tiplerini temsil eder (Daire, Villa, Ofis, vb.)
/// </summary>
public class PropertyType : BaseEntity
{
    /// <summary>
    /// Emlak tipi adı (örn: Daire, Villa, Müstakil Ev)
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Emlak tipi açıklaması
    /// </summary>
    public string? Description { get; set; }
    
    // ========== NAVİGATİON PROPERTİES ==========
    
    /// <summary>
    /// Bu tipe ait tüm emlak ilanları
    /// </summary>
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}