using CleanArch.Net.Domain.Contracts.Data;
using CleanArch.Net.Domain.Entities;
using CleanArch.Net.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Net.Infrastructure.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
        => await context.Products.ToListAsync();

    public async Task<Product> GetByIdAsync(int id)
    {
        var entity = await context.Products.FindAsync(id);
        
        if (entity is null)
            throw new InvalidOperationException("Product not found");
        return entity;
    }

    public async Task AddAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var someEntity = await context.Products.AnyAsync(entity => entity.Id == product.Id);
        
        if (someEntity is false)
            throw new InvalidOperationException($"Product with {product.Id} not exists");
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var entity = await context.Products.FindAsync(id);
        if (entity is null)
            throw new InvalidOperationException("Product not found");
        context.Products.Remove(entity);
        await context.SaveChangesAsync();
    }
}