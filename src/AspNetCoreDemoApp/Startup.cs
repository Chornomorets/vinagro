using System;
using AspNetCoreDemoApp.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

            var builder = new PostgreSqlConnectionStringBuilder("postgres://idjwltepabhcst:1b36a53486fd99f4549577a743a0a25292089b5b88b22c6505a23d97b4e394b2@ec2-79-125-4-96.eu-west-1.compute.amazonaws.com:5432/de0ehmmkkm4sns")
            {
                Pooling = true,
                TrustServerCertificate = true,
                SslMode = SslMode.Require
            };

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<Context>(options => options.UseNpgsql(builder.ToString()));

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