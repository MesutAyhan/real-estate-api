namespace RealEstateAPI.Core.Enums;

/// <summary>
/// Müşteri sorgusunun durumunu belirtir
/// </summary>
public enum InquiryStatus
{
    /// <summary>
    /// Yeni gelen sorgu, henüz işleme alınmamış
    /// </summary>
    New = 1,
    
    /// <summary>
    /// Müşteri ile iletişime geçildi
    /// </summary>
    Contacted = 2,
    
    /// <summary>
    /// Sorgu çözüldü, müşteri memnun
    /// </summary>
    Resolved = 3,
    
    /// <summary>
    /// Sorgu kapatıldı (çözülmeden)
    /// </summary>
    Closed = 4
}