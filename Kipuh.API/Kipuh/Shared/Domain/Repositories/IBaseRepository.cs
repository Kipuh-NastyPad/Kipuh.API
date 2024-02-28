namespace Kipuh.API.Kipuh.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity, in TKey>
{
    Task<TEntity?> FindAsync(TKey id);
    Task AddAsync(TEntity newEntityObject);
    void Update(TEntity updatedEntityObject);
    void Remove(TEntity toDeleteEntityObject);
    Task<bool> Exists(TKey id);
}