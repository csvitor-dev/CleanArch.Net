using CleanArch.DAO.Contexts;
using CleanArch.Domain.Contracts.Data.Repositories;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.DAO.Repositories;

public class BaseRepository<T>(AppDbContext context)
    : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context = context;

    public async Task CreateAsync(T entity)
    {
        entity.CreatedOn = DateTimeOffset.UtcNow;
        await Context.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        entity.DeletedOn = DateTimeOffset.UtcNow;
        Context.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAllAsync(CancellationToken token)
        => await Context.Set<T>().ToListAsync();

    public async Task<T?> FindByIdAsync(Guid id, CancellationToken token)
        => await Context.Set<T>()
            .FirstOrDefaultAsync(entity => entity.Id == id, token);

    public void Update(T entity)
    {
        entity.UpdatedOn = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }
}