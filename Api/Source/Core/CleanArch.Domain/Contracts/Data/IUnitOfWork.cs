namespace CleanArch.Domain.Contracts.Data;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token);
}