using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Contracts.Data.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> FindByIdAsync(Guid id, CancellationToken token); 
    Task<IEnumerable<T>> FindAllAsync(CancellationToken token); 
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}