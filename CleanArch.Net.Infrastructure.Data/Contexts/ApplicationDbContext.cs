using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CleanArch.Net.Domain.Entities;

namespace CleanArch.Net.Infrastructure.Data.Contexts;

public class ApplicationDbContext
    (DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) 
        => builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
}
