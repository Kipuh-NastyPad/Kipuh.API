using Kipuh.API.Kipuh.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kipuh.API.Kipuh.Shared.Persistence;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbSet<TEntity> Entities;
    protected readonly AppDbContext AppDbContext;

    public BaseRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
        Entities = AppDbContext.Set<TEntity>();
    }

    public virtual async Task<TEntity?> FindAsync(TKey id)
    {
        return await Entities.FindAsync(id);
    }

    public virtual async Task AddAsync(TEntity newEntityObject)
    {
        await Entities.AddAsync(newEntityObject);
    }

    public virtual void Update(TEntity updatedEntityObject)
    {
        Entities.Update(updatedEntityObject);
    }

    public virtual void Remove(TEntity toDeleteEntityObject)
    {
        Entities.Remove(toDeleteEntityObject);
    }

    public virtual async Task<bool> Exists(TKey id)
    {
        return await Entities.FindAsync(id) != null;
    }
}