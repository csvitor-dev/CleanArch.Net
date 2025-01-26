using CleanArch.Net.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Net.Infrastructure.IoC.DependencyInjection;

public static class InfraDataDi
{
    public static void AddInfrastructure(this IServiceCollection self, string connection)
    {
        self.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connection));
        self.AddDatabaseDeveloperPageExceptionFilter();

        self.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

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