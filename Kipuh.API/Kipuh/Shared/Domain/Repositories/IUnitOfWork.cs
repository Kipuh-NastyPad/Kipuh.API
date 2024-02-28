namespace Kipuh.API.Kipuh.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}