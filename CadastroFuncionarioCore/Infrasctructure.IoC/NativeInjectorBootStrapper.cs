using Application;
using Domain.Contracts.Application;
using Domain.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Infrasctructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IFuncionarioApplication, FuncionarioApplication>();

            // Infra - Data
            //services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FuncionarioContext>();
        }
    }
}