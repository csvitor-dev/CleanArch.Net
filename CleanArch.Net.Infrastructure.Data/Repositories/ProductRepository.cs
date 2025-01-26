using CleanArch.Net.Domain.Contracts.Data;
using CleanArch.Net.Domain.Entities;
using CleanArch.Net.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Net.Infrastructure.Data.Repositories;

public class ProductRepository(ApplicationDbContext _context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
        => await _context.Products.ToListAsync();
}