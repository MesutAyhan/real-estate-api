using System.Linq.Expressions;

namespace RealEstateAPI.Data.Repositories;

/// <summary>
/// Generic repository interface
/// Tüm entity'ler için ortak CRUD işlemleri
/// </summary>
public interface IRepository<T> where T : class
{
    // Okuma işlemleri
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    
    // Yazma işlemleri
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    
    // Sayma
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
}