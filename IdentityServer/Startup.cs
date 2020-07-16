using IdentityServer4.EntityFramework.DbContexts;
using IdentityServerEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //services.AddDbContext<AppDbContext>(config =>
            //{
            //    //config.UseOracle(connectionString);
            //    config.UseInMemoryDatabase("Memory");
            //});

            //services.AddIdentity<IdentityUser, IdentityRole>(config =>
            //{
            //    config.Password.RequiredLength = 4;
            //    config.Password.RequireDigit = false;
            //    config.Password.RequireNonAlphanumeric = false;
            //    config.Password.RequireUppercase = false;
            //})
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.Cookie.Name = "IdentityServer.Cookie";
            //    config.LoginPath = "/Auth/Login";
            //    config.LogoutPath = "/Auth/Logout";
            //});

            services.AddIdentityServer()
                //.AddAspNetIdentity<IdentityUser>()
                .AddDeveloperSigningCredential()
                // this adds the config data from DB (clients, resources, CORS)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseOracle(connectionString,
                            bd => bd.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                //.AddOperationalStore(options =>
                //{
                //    options.ConfigureDbContext = builder => builder.UseOracle(connectionString,
                //            bd => bd.MigrationsAssembly(migrationsAssembly));

                //    // this enables automatic token cleanup. this is optional.
                //    options.EnableTokenCleanup = true;
                //    options.TokenCleanupInterval = 30; // interval in seconds, short for testing
                //    //options.DefaultSchema = "IdentityServer";
                //})
                ;
            // this is something you will want in production to reduce load on and requests to the DB
            services.AddCors(confg =>
                 confg.AddPolicy("AllowAll",
                     p => p.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()));

            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseStaticFiles();

            app.UseIdentityServer();

            if (_env.IsDevelopment())
            {
                app.UseCookiePolicy(new CookiePolicyOptions()
                {
                    MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

    }
}