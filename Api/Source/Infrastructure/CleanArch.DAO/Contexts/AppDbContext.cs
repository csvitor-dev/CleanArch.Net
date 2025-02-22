using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.DAO.Contexts;

public sealed class AppDbContext
    (DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = default!;
}