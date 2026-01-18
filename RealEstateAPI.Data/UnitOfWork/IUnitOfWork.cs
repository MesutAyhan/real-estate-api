using RealEstateAPI.Data.Repositories;

namespace RealEstateAPI.Data.UnitOfWork;

/// <summary>
/// Unit of Work pattern interface
/// Tüm repository'leri ve transaction yönetimini içerir
/// </summary>
public interface IUnitOfWork : IDisposable
{
    // Repository'ler
    IPropertyRepository Properties { get; }
    IPropertyTypeRepository PropertyTypes { get; }
    IPropertyImageRepository PropertyImages { get; }
    IInquiryRepository Inquiries { get; }

    // Transaction yönetimi
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}