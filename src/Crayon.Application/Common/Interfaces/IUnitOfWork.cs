namespace Crayon.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
