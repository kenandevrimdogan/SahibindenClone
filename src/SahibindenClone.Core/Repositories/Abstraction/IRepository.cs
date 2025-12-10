using System.Linq.Expressions;
using SahibindenClone.Domain.Entities;

namespace SahibindenClone.Core.Repositories.Abstraction;

public interface IRepository<T> where T : BaseEntity
{
    // Query Methods
    Task<T> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<T> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);

    Task<IEnumerable<T>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAllAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);

    Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);

    Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<T> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);

    // Paging
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);

    // Count Methods
    Task<int> CountAsync(
        CancellationToken cancellationToken = default);

    Task<int> CountAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default);

    // CRUD Operations
    Task<T> AddAsync(
        T entity,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> AddRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(
        T entity,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> UpdateRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        T entity,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteRangeAsync(
        IEnumerable<T> entities,
        CancellationToken cancellationToken = default);

    // Soft Delete (for AuditableEntity)
    Task<bool> SoftDeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<bool> SoftDeleteAsync(
        T entity,
        CancellationToken cancellationToken = default);

    // Query Building
    IQueryable<T> Query();
    IQueryable<T> QueryNoTracking();
}
