using Kipuh.API.Kipuh.Shared.Domain.Repositories;

namespace Kipuh.API.Kipuh.Shared.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CompleteAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}