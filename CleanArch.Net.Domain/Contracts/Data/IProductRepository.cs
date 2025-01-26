using CleanArch.Net.Domain.Entities;

namespace CleanArch.Net.Domain.Contracts.Data;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetProductsAsync();
}