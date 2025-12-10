using SahibindenClone.Domain.Entities;

namespace SahibindenClone.Core.Repositories.Abstraction;

public interface IUnitOfWork : IDisposable
{
    // Repositories
    IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        
    // Transaction Methods
    Task<int> SaveChangesAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}