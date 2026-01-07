namespace RealEstateAPI.Core.Entities;

/// <summary>
/// Tüm entity'lerin miras alacağı temel sınıf
/// Ortak özellikleri içerir (Id, CreatedAt, UpdatedAt, IsDeleted)
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Her kaydın benzersiz kimlik numarası
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Kaydın oluşturulma tarihi
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Kaydın son güncellenme tarihi
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// Soft delete için kullanılır
    /// True ise kayıt silinmiş sayılır ama veritabanından fiziksel olarak silinmez
    /// </summary>
    public bool IsDeleted { get; set; } = false;
}