using Microsoft.AspNetCore.Identity;

namespace RealEstateAPI.Core.Entities;

/// <summary>
/// Sistem rollerini temsil eder
/// Identity'den türetilir
/// </summary>
public class AppRole : IdentityRole
{
    /// <summary>
    /// Rolün açıklaması
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Rolün oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// Sistemde kullanılan rol sabitleri
/// </summary>
public static class AppRoles
{
    public const string Admin = "Admin";
    public const string Agent = "Agent";
    public const string User = "User";
}