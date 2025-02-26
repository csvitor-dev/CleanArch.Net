using System.Threading.Tasks;
using CleanArch.DAO.Contexts;
using CleanArch.DAO.Repositories;
using CleanArch.DAO.Services;
using CleanArch.Domain.Contracts.Data;
using CleanArch.Domain.Contracts.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.IoC.Extensions;

public static class DataAccessDiExtension
{
    public static void AddDataAccessLayer(this IServiceCollection self, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("db");

        self.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connection));

        self.AddScoped<IUnitOfWork, UnitOfWork>();
        self.AddScoped<IUserRepository, UserRepository>();
    }

    public static async Task CreateDatabaseAsync(this IServiceScope self)
    {
        var context = self.ServiceProvider.GetService<AppDbContext>();

        await context?.Database.EnsureCreatedAsync();
    }
}