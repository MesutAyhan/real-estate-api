namespace RealEstateAPI.Core.Enums;

/// <summary>
/// Emlak ilanının mevcut durumunu belirtir
/// </summary>
public enum PropertyStatus
{
    /// <summary>
    /// İlan müsait, satılabilir veya kiralanabilir
    /// </summary>
    Available = 1,
    
    /// <summary>
    /// İlan rezerve edilmiş, görüşmeler devam ediyor
    /// </summary>
    Reserved = 2,
    
    /// <summary>
    /// İlan satılmış
    /// </summary>
    Sold = 3,
    
    /// <summary>
    /// İlan kiralanmış
    /// </summary>
    Rented = 4
}