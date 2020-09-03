using System;
using System.Reflection;
using ExpensesTracker.Identity.Data.Context;
using ExpensesTracker.Identity.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesTracker.Identity.Infrastructure.AspNetIdentity
{
    public static class AspNetIdentityConfiguration
    {
        public static void ConfigureAspNetIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("IdentityContext");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseSqlServer(connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var passwordSettings = configuration.GetSection("AspNetIdentity:Password");
            var lockoutSettings = configuration.GetSection("AspNetIdentity:Lockout");
            var userSettings = configuration.GetSection("AspNetIdentity:User");
            var cookieSettings = configuration.GetSection("AspNetIdentity:ApplicationCookie");

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = bool.Parse(passwordSettings["RequireDigit"]);
                options.Password.RequireLowercase = bool.Parse(passwordSettings["RequireLowercase"]);
                options.Password.RequireNonAlphanumeric = bool.Parse(passwordSettings["RequireNonAlphanumeric"]);
                options.Password.RequireUppercase = bool.Parse(passwordSettings["RequireUppercase"]);
                options.Password.RequiredLength = int.Parse(passwordSettings["RequiredLength"]);
                options.Password.RequiredUniqueChars = int.Parse(passwordSettings["RequiredUniqueChars"]);

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(int.Parse(lockoutSettings["DefaultLockoutTimeSpanInMinutes"]));
                options.Lockout.MaxFailedAccessAttempts = int.Parse(lockoutSettings["MaxFailedAccessAttempts"]);
                options.Lockout.AllowedForNewUsers = bool.Parse(lockoutSettings["AllowedForNewUsers"]);

                // User settings.
                options.User.AllowedUserNameCharacters = userSettings["AllowedUserNameCharacters"];
                options.User.RequireUniqueEmail = bool.Parse(userSettings["RequireUniqueEmail"]);
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = bool.Parse(cookieSettings["HttpOnly"]);
                options.ExpireTimeSpan = TimeSpan.FromMinutes(int.Parse(cookieSettings["ExpireTimeSpanInMinutes"]));

                options.LoginPath = cookieSettings["LoginPath"];
                options.AccessDeniedPath = cookieSettings["AccessDeniedPath"];
                options.SlidingExpiration = bool.Parse(cookieSettings["SlidingExpiration"]);
            });
        }
    }
}
