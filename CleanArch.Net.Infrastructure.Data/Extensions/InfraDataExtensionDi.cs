using CleanArch.Net.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Net.Infrastructure.Data.Extensions;

public static class InfraDataExtensionDi
{
    public static void AddInfrastructure(this IServiceCollection self, string connection)
    {
        self.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connection));
        self.AddDatabaseDeveloperPageExceptionFilter();

        self.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
}