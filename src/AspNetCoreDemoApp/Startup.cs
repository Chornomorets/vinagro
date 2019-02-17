using System;
using AspNetCoreDemoApp.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Common.AspNetCoreDemoApp;
using AspNetCoreDemoApp.Common;

namespace AspNetCoreDemoApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services    
                .AddMvcCore()
                .AddCors()
                .AddJsonFormatters();
           
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<Context>(options => options.UseNpgsql(EnvironmentConfigManager.GetConnectionString()));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseCors(builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                )
                .UseMvcWithDefaultRoute();

            if (env.IsProduction())
            {
                Console.WriteLine("https");
                var options = new RewriteOptions()
                    .AddRedirectToHttpsPermanent();

                app.UseRewriter(options);
            }
        }
    }
}