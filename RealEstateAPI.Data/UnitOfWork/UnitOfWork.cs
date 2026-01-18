using Microsoft.EntityFrameworkCore.Storage;
using RealEstateAPI.Data.Context;
using RealEstateAPI.Data.Repositories;

namespace RealEstateAPI.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    // Repository'leri lazy loading ile oluştur
    private IPropertyRepository? _properties;
    private IPropertyTypeRepository? _propertyTypes;
    private IPropertyImageRepository? _propertyImages;
    private IInquiryRepository? _inquiries;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    // Repository property'leri (ilk erişimde oluşturulur)
    public IPropertyRepository Properties
    {
        get
        {
            if (_properties == null)
                _properties = new PropertyRepository(_context);
            return _properties;
        }
    }

    public IPropertyTypeRepository PropertyTypes
    {
        get
        {
            if (_propertyTypes == null)
                _propertyTypes = new PropertyTypeRepository(_context);
            return _propertyTypes;
        }
    }

    public IPropertyImageRepository PropertyImages
    {
        get
        {
            if (_propertyImages == null)
                _propertyImages = new PropertyImageRepository(_context);
            return _propertyImages;
        }
    }

    public IInquiryRepository Inquiries
    {
        get
        {
            if (_inquiries == null)
                _inquiries = new InquiryRepository(_context);
            return _inquiries;
        }
    }

    // SaveChanges
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    // Transaction yönetimi
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    // Dispose
    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}