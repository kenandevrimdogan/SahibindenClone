using System.Linq.Expressions;
using SahibindenClone.Domain.Entities;

namespace SahibindenClone.Core.Repositories.Abstraction;

public interface IRepository<T> where T : BaseEntity
{
    // Query Methods
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        
    // Paging
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber, 
        int pageSize, 
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes);
        
    // Count Methods
    Task<int> CountAsync();
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        
    // CRUD Operations
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> DeleteAsync(T entity);
    Task<bool> DeleteRangeAsync(IEnumerable<T> entities);
        
    // Soft Delete (for AuditableEntity)
    Task<bool> SoftDeleteAsync(Guid id);
    Task<bool> SoftDeleteAsync(T entity);
        
    // Query Building
    IQueryable<T> Query();
    IQueryable<T> QueryNoTracking();
}