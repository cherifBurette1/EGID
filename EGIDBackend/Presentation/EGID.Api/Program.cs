using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EGID.Api.Helper;
using EGID.Presistance;
using EGID.Service.Features.Common.Interfaces;

namespace EGID.Api
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                using (var concreteContext = (EGIDEntities)scope.ServiceProvider.GetService<IEGIDEntities>())
                {
                    concreteContext.Database.SetCommandTimeout(600);
                    concreteContext.Database.Migrate();

                    var environment = scope.ServiceProvider.GetService<IWebHostEnvironment>();
                    EGIDEntitiesSeed.ApiInitialize(concreteContext);
                }
                using (var concreteContext = (EGIDAuditDbContext)scope.ServiceProvider.GetService<IEGIDAuditDbContext>())
                {
                    concreteContext.Database.Migrate();
                }
            }
            host.Run();
        }

        /// <summary>
        /// CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
    }
}