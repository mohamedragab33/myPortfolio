using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.UnitOfWork;
using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(

                    options => options.UseSqlServer(_config.GetConnectionString("PortfolioDB"))

                );
            services.AddScoped(typeof(IUnitOfWorkRepository<>), typeof(UnitOfWork<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllersWithViews();
        }

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    
                    "defaultRoute", "{controller}/{action}/{id}",                         
                new { controller = "Home", action = "Index", id = "" }

                    );



            });
        }
    }
}
