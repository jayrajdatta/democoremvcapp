using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp2._2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DemoApp2._2
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddXmlSerializerFormatters();
            //services.AddMvcCore(); //services.AddMvc() internally call services.AddMvcCore();

            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            //app.UseMvcWithDefaultRoute(); //default route named 'default' and the following template: '{controller=Home}/{action=Index}/{id?}'

            //app.UseMvc( routes => {
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

            //use route attribute instead of above conventional routes
            app.UseMvc();

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World! Current Time:" + DateTime.Now.ToLongTimeString() + "\n");
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(_config["MyKey"]);
            //});
        }
    }
}
