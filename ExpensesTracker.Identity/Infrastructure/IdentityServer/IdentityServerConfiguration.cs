using System.Reflection;
using ExpensesTracker.Identity.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesTracker.Identity.Infrastructure.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static void ConfigureIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("IdentityContext");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var ids = services.AddIdentityServer()
                .AddDeveloperSigningCredential(); // To be replaced in a later stage

            ids.AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddOperationalStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly))
                );

            // ASP.NET Identity integration
            ids.AddAspNetIdentity<ApplicationUser>();
        }
    }
}
