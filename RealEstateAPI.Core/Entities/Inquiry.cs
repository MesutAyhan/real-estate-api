using RealEstateAPI.Core.Enums;

namespace RealEstateAPI.Core.Entities;

/// <summary>
/// Müşterilerin emlak ilanları hakkında gönderdikleri sorguları temsil eder
/// Hem kayıtlı hem kayıtsız kullanıcılar sorgu gönderebilir
/// </summary>
public class Inquiry : BaseEntity
{
    // ========== İLETİŞİM BİLGİLERİ ==========
    
    /// <summary>
    /// Sorgu gönderen kişinin adı soyadı
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Sorgu gönderen kişinin e-posta adresi
    /// </summary>
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Sorgu gönderen kişinin telefon numarası
    /// </summary>
    public string? Phone { get; set; }
    
    /// <summary>
    /// Sorgu mesajı
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Sorgu durumu (Yeni, İletişime Geçildi, Çözüldü, Kapatıldı)
    /// </summary>
    public InquiryStatus Status { get; set; } = InquiryStatus.New;
    
    // ========== İLİŞKİLER (FOREIGN KEYS) ==========
    
    /// <summary>
    /// Bu sorgunun gönderildiği emlak ilanının ID'si
    /// </summary>
    public int PropertyId { get; set; }
    
    /// <summary>
    /// Eğer sorgu kayıtlı bir kullanıcı tarafından gönderildiyse kullanıcı ID'si
    /// Opsiyonel - kayıtsız kullanıcılar da sorgu gönderebilir
    /// </summary>
    public string? UserId { get; set; }
    
    // ========== NAVİGATİON PROPERTİES ==========
    
    /// <summary>
    /// Bu sorgunun gönderildiği emlak ilanı
    /// </summary>
    public Property Property { get; set; } = null!;
    
    /// <summary>
    /// Sorguyu gönderen kullanıcı (eğer kayıtlı kullanıcı ise)
    /// </summary>
    public AppUser? User { get; set; }
}