using CleanArch.Net.Application.UseCases.Product;
using CleanArch.Net.Application.UseCases.Product.Contracts;
using CleanArch.Net.Domain.Contracts.Data;
using CleanArch.Net.Infrastructure.Data.Contexts;
using CleanArch.Net.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Net.Infrastructure.IoC.DependencyInjection;

public static class InfraDataExtensionDi
{
    public static void AddInfrastructure(this IServiceCollection self, string connection)
    {
        self.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connection));
        self.AddDatabaseDeveloperPageExceptionFilter();

        self.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        self.AddScoped<IProductRepository, ProductRepository>();
    }

    public static void AddUseCases(this IServiceCollection self)
        => self.AddScoped<IProductUseCase, ProductUseCase>();

    public static async Task ApplyMigrations(this IServiceCollection self)
    {
        using var scope = self.BuildServiceProvider().CreateScope();
        var provider = scope.ServiceProvider;

        try
        {
            await provider.GetService<ApplicationDbContext>()?.Database.MigrateAsync()!;
        }
        catch (Exception ex)
        {
            await Console.Error.WriteLineAsync($"Failed to migrate database.\n[{ex.Message}]");
        }
    }
}