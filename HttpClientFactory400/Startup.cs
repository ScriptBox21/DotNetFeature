using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;

namespace HttpClientFactory400
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
            services.AddControllers();

            //TODO: APPLYING A POLICY
            services.AddHttpClient("github")
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10)));


            //TODO: REUSING POLICIES
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));

            services.AddHttpClient("github")
              .AddPolicyHandler(timeoutPolicy);

            services.AddHttpClient("google")
              .AddPolicyHandler(timeoutPolicy);


            //TODO: TRANSIENT FAULT HANDLING
            services.AddHttpClient("github")
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3));



            //TODO: NoOp
            var retryPolicy = HttpPolicyExtensions
              .HandleTransientHttpError()
              .RetryAsync(3);

            var noOp = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            services.AddHttpClient("github")
              .AddPolicyHandler(request => request.Method == HttpMethod.Get ? retryPolicy : noOp);



            //TODO: USING A POLICYREGISTRY
            var registry = services.AddPolicyRegistry();

            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(30));

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);

            services.AddHttpClient("github")
                .AddPolicyHandlerFromRegistry("regular");
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
