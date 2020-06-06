using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Middleware300
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Middleware 
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("1st middleware Start.");

                await next(); // if without next(), 2nd middleware does not call.

                await context.Response.WriteAsync("1st middleware End.");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("2nd middleware Start.");
                await next();
                await context.Response.WriteAsync("2nd middleware End.");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("3rd middleware Start.");

                await next(); // if without next(), UseRouting(), UseEndpoints() does not call("Hello World!")
            });
            #endregion

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Test!");
                });
            });
        }
    }
}
