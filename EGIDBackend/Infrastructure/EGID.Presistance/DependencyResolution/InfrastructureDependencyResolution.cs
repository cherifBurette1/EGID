﻿using Dapper;
using Microsoft.Extensions.DependencyInjection;
using EGID.Ground;
using EGID.Presistance.Features.Common.Implementation;
using EGID.Presistance.Infrastructure;
using EGID.Service.DependencyResolution;
using EGID.Service.Features.Common.Interfaces;
using System;

namespace EGID.Presistance.DependencyResolution
{
    public static class InfrastructureDependencyResolution
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var interfaceAssembly = typeof(CoreDependencyResolution).Assembly;
            var implementationAssembly = typeof(InfrastructureDependencyResolution).Assembly;

            //inject by convention
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Factory"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Helper") && x.Name != "IMimeTypeHelper");
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Schedular"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Repository"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Validator"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Validators"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Strategy"));
            services.AddTransientByConvention(interfaceAssembly, implementationAssembly, x => x.Name.EndsWith("Director"));

            //inject UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            //inject lazy
            services.AddTransient(typeof(Lazy<>), typeof(Lazier<>));

            SqlMapper.AddTypeHandler(new DateTimeHandler());

            //var provider = new FileExtensionContentTypeProvider();
            //provider.Mappings.Add(".dnct", "application/dotnetcoretutorials");

            return services;
        }
        internal class Lazier<T> : Lazy<T> where T : class
        {
            public Lazier(IServiceProvider provider)
                : base(() => provider.GetRequiredService<T>())
            {
            }
        }
    }
}
