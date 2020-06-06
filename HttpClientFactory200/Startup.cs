using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HttpClientFactory200
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
            //TODO: NAMED CLIENT
            //services.AddHttpClient("GitHubClient", client =>
            //{
            //    client.BaseAddress = new Uri("https://api.github.com/");
            //    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //    client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");
            //});


            //TODO: TYPED CLIENTS
            //services.AddHttpClient<MyGitHubClient>(client =>
            //{
            //    client.BaseAddress = new Uri("https://api.github.com/");
            //    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //    client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");
            //});

            //TODO: ENCAPSULATING THE HTTPCLIENT
            services.AddHttpClient<IMyGitHubClient, EncapsulatingHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}




/*
 * https://www.stevejgordon.co.uk/introduction-to-httpclientfactory-aspnetcore
*/