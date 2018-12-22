﻿using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sms.Domain;
using Sms.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Sms.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }
        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddAutoMapper();
            services.AddDbContext<SmsDbContext>(options =>
            {
                options.UseNpgsql(_hostingEnvironment.IsDevelopment()
                    ? Configuration.GetConnectionString("Development")
                    : Configuration.GetConnectionString("Production"));
                options.EnableSensitiveDataLogging();

                options.ConfigureWarnings(builder => builder.Throw());
            });

            DataAccessRegistry.RegisterRepository(services);
            ComponentAccessRegistry.RegisterServices(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddMvc().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            //    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddConsole()
                .AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // This will add "Libs" as another valid static content location
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Dashboard}/{action=Index}");
            });


            app.UseCookiePolicy();
            //app.UseMvcWithDefaultRoute();
        }
    }
}
