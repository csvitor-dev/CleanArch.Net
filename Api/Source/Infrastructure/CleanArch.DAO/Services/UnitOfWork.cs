using CleanArch.DAO.Contexts;
using CleanArch.Domain.Contracts.Data;

namespace CleanArch.DAO.Services;

internal class UnitOfWork
    (AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken token)
        => await context.SaveChangesAsync(token);
}