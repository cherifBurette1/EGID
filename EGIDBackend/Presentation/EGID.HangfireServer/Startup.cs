
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using EGID.Ground;
using EGID.HangfireServer.Filters;
using EGID.HangfireServer.Notifiers;
using EGID.HangfireServer.SignalRHubs;
using EGID.Presistance;
using EGID.Presistance.DependencyResolution;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Common.Interfaces.Notifiers;
using System;
using EGID.Presistance.Features.Common.Implementation;
using EGID.Service.Feature.Stocks.Interfaces.Services;
using Qorrect.Service.Feature.Stocks.Implementation.Services;

namespace EGID.HangfireServer
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        //private static ConnectionMultiplexer _redis;
        public Startup(IConfiguration configurations, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configurations.ConfigurationManager = builder.Build();
            _env = env;
            //_redis = ConnectionMultiplexer.Connect(Configurations.HangfireConnectionString);
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver =
              new CamelCasePropertyNamesContractResolver()); ;
            services.AddRazorPages();
            //Register Cors Origin
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("defaultHangfire", policy =>
                {
                    policy.WithOrigins(
                        $"{Configurations.FrontendAngularBaseUrl}",
                        "http://localhost:4200")
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(1728000));

                });
            });
            //Register Hangfire 
            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            //.UseRedisStorage(_redis, new Hangfire.Redis.RedisStorageOptions()
            //{
            //    Prefix = $"EGIDHangfire-{_env.EnvironmentName}"
            //}));
            .UseSqlServerStorage(Configurations.HangfireConnectionString, new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                UsePageLocksOnDequeue = true,
                DisableGlobalLocks = true
            }));


            // Add the processing server as IHostedService
            services.AddHangfireServer(options =>
            {
                options.SchedulePollingInterval = TimeSpan.FromSeconds(1);
                options.Queues = new[] { "alpha", "beta", "default" };
            });
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            }
                );

            GlobalJobFilters.Filters.Add(new JobRetentionFilter());

            // register redis cache
            services.AddStackExchangeRedisCache(options =>
            {
                //options.ConfigurationOptions = new ConfigurationOptions()
                //{
                //    EndPoints = { Configurations.RedisCacheConnectionString },
                //    ChannelPrefix = $"RedisCache-{ _env.EnvironmentName }"
                //};
                options.Configuration = Configurations.RedisCacheConnectionString;
            });



            ConfigureIoC(services);
        }
        public void ConfigureIoC(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<IEGIDEntities, EGIDEntities>(o => o.UseSqlServer(Configurations.EGIDConnectionString));

            services.AddInfrastructure();
            services.AddScoped<IStocksService, StocksService>();
            //services.AddScoped<IBrokerFactory, BrokerFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IStockBackgroundNotifier, StockBackgroundConcreteNotifier>();
            services.AddTransient(provider => new Lazy<IStockBackgroundNotifier>(provider.GetService<IStockBackgroundNotifier>));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStocksService stocksService)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("defaultHangfire");
            app.UseAuthentication();
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); //Routes for pages
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<StocksHub>("/Stock");
            });
            RecurringJob.AddOrUpdate("updateAndGetStocks", () => stocksService.UpdateAndGetStocks(), "*/10 * * * * *");
        }
    }
}
