using Microsoft.AspNetCore.Identity;

namespace RealEstateAPI.Core.Entities;

/// <summary>
/// Sistem kullanıcılarını temsil eder
/// Identity'den türetilir (Email, Password, PhoneNumber otomatik gelir)
/// </summary>
public class AppUser : IdentityUser
{
    /// <summary>
    /// Kullanıcının adı
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>
    /// Kullanıcının soyadı
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>
    /// Profil resmi URL'si
    /// </summary>
    public string? ProfilePicture { get; set; }
    
    // ========== EMLAKÇI BİLGİLERİ ==========
    
    /// <summary>
    /// Bu kullanıcının emlakçı olup olmadığı
    /// True ise Agent rolündedir
    /// </summary>
    public bool IsAgent { get; set; } = false;
    
    /// <summary>
    /// Emlakçının çalıştığı firma adı
    /// </summary>
    public string? AgencyName { get; set; }
    
    /// <summary>
    /// Emlakçının lisans numarası
    /// </summary>
    public string? LicenseNumber { get; set; }
    
    // ========== TARİH BİLGİLERİ ==========
    
    /// <summary>
    /// Hesabın oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Hesabın son güncellenme tarihi
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// Hesap silinmiş mi? (Soft delete)
    /// </summary>
    public bool IsDeleted { get; set; } = false;
    
    // ========== NAVİGATİON PROPERTİES (İLİŞKİLER) ==========
    
    /// <summary>
    /// Bu emlakçının oluşturduğu ilanlar
    /// Sadece IsAgent = true olan kullanıcılar için dolu
    /// </summary>
    public ICollection<Property> Properties { get; set; } = new List<Property>();
    
    /// <summary>
    /// Bu kullanıcının gönderdiği sorgular
    /// </summary>
    public ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
    
    // ========== COMPUTED PROPERTY ==========
    
    /// <summary>
    /// Kullanıcının tam adı (FirstName + LastName)
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";
}