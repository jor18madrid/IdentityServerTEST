using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = CreateWebHostBuilder(args).Build();
            
            using (var scope = webhost.Services.CreateScope())
            {


                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var user = new IdentityUser("admin");
                userManager.CreateAsync(user, "admin").GetAwaiter().GetResult();



                //scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                //var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

                //context.Database.Migrate();

                //if (!context.ApiResources.Any())
                //{
                //    foreach (var resource in Configuration.GetApis())
                //    {
                //        context.ApiResources.Add(resource);
                //    }
                //    context.SaveChanges();
                //}

                //if (!context.IdentityResources.Any())
                //{
                //    foreach (var resource in Configuration.GetIdentityResources())
                //    {
                //        context.IdentityResources.Add(resource.ToEntity());
                //    }
                //    context.SaveChanges();
                //}


                //if (!context.Clientes.Any())
                //{
                //    foreach (var clientes in Configuration.GetClients())
                //    {
                //        context.Clientes.Add(clientes);
                //    }
                //    context.SaveChanges();
                //}

            }

            webhost.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
    }
}



//public static void Main(string[] args)
//{
//    CreateWebHostBuilder(args).Build().Run();
//}

//public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//    WebHost.CreateDefaultBuilder(args)
//        .UseStartup<Startup>();