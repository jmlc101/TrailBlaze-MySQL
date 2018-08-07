using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using WebApplication1.Models;
using WebEssentials.AspNetCore.Pwa;

namespace WebApplication1
{
    public class Startup
    {
        private string _apiKey = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Secrets>(Configuration);
            _apiKey = Configuration["MySecret"];

            services.AddDbContext<JMCapstoneDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDistributedMemoryCache();
            services.AddSession(options => {// TODO - Set Timeout time to lower (1) for testing purposes, when testing User routing based on session status.
                options.IdleTimeout = TimeSpan.FromMinutes(20);//You can set Time   
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 8080;
            });

            services.AddMvc();

            services.AddProgressiveWebApp();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Note: A test to see that Secret is "Not Null".
            /*
            var result = string.IsNullOrEmpty(_apiKey) ? "Null" : "Not Null";
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Secret is {result}");
            });
            */

            // TODO - added as per: https://stackoverflow.com/questions/28664686/how-do-i-get-client-ip-address-in-asp-net-core
            // had to add dependency to "Microsoft.AspNetCore.HttpOverrides": "2.0.2" in .csproj
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
            ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession(); // TODO - added as per "session" guide

            // TODO - change this to control first page accessed?
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Welcome}/{action=Index}/{id?}");
            });

            app.UseHttpsRedirection();

        }
    }
}
