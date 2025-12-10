using SahibindenClone.Domain.Entities;

namespace SahibindenClone.Core.Repositories.Abstraction;

public interface IUnitOfWork : IDisposable
{
    // Repositories
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        
    // Transaction Methods
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}