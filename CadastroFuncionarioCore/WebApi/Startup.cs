﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.AutoMapper;
using Infrastructure.Data;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Configurations;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Set database. 
            //if (Configuration["AppConfig:UseInMemoryDatabase"] == "true")
            //{
            //    services.AddDbContext<FuncionarioContext>(opt => opt.UseInMemoryDatabase("FuncionarioDbMemory"));
            //}
            //else
            //{
            //    services.AddDbContext<FuncionarioContext>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //}
            services.AddDbContext<FuncionarioContext>(opt => opt.UseInMemoryDatabase("FuncionarioDbMemory"));

            //services.AddTransient<IFuncionarioApplication, FuncionarioApplication>();

            services.AddAutoMapperSetup();
            services.AddMvc();
            RegisterServices(services);
        }
        
        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();
        }
    }
}