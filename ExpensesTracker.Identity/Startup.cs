using ExpensesTracker.Identity.Data.Seed;
using ExpensesTracker.Identity.Infrastructure.AspNetIdentity;
using ExpensesTracker.Identity.Infrastructure.IdentityServer;
using ExpensesTracker.Identity.Services.EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExpensesTracker.Identity
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.Configure<AspNetIdentityOptions>(_configuration);

            services.ConfigureAspNetIdentity(_configuration);
            services.ConfigureIdentityServer(_configuration);

            services.AddAuthentication()
              .AddGoogle(options =>
              {
                  var googleAuthNSection = _configuration.GetSection("Authentication:Google");

                  options.ClientId = googleAuthNSection["ClientId"];
                  options.ClientSecret = googleAuthNSection["ClientSecret"];
              });

            // Configure from DB
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

            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}
