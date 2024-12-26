using CleanArch.Net.Infrastructure.Data.Contexts;
using CleanArch.Net.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArch.Net.Infrastructure.Data.Services;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite(InfraConfiguration.ConnectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}