namespace SimpleBlog.Domain.Common;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
