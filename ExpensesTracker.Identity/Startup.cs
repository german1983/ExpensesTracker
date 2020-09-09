using ExpensesTracker.Identity.Data.Seed;
using ExpensesTracker.Identity.Infrastructure.AspNetIdentity;
using ExpensesTracker.Identity.Infrastructure.IdentityServer;
using ExpensesTracker.Identity.Services.EmailService;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace ExpensesTracker.Identity
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
            }

            services.AddControllers();
            services.AddRazorPages();

            services.Configure<AspNetIdentityOptions>(_configuration);

            services.ConfigureAspNetIdentity(_configuration);
            services.ConfigureIdentityServer(_configuration);

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("ApiScope", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.RequireClaim("scope", "identity");
                //});

                // Scope: identity.admin
                // Roles: N/A
                options.AddPolicy("UserManager",
                    policy =>
                    {
                        policy.RequireScope("identity.admin");
                    });
            });

            // TODO: Configure from DB
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication("identity.schema", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.RequireHttpsMetadata = true;
                    options.ApiName = "identity";
                    options.RoleClaimType = JwtClaimTypes.Role;
                })
               .AddGoogle(options =>
                {
                    var googleAuthNSection = _configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });

            // TODO: Configure from DB
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("https://localhost:5003")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Services
            services.AddSingleton<IEmailSender, EmailSender>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.InitializeDb();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("default");

            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
