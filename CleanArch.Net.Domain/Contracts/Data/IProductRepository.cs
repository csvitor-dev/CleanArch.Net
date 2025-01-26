using CleanArch.Net.Domain.Entities;

namespace CleanArch.Net.Domain.Contracts.Data;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllAsync();
    public Task<Product> GetByIdAsync(int id);
    public Task AddAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task RemoveAsync(int id);
}