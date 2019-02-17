using Common.AspNetCoreDemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Common
{
    public static class EnvironmentConfigManager
    {

        public static string GetDatabaseURL()
        {
            var databaseURL = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (databaseURL == null)
            {
                databaseURL = Environment.GetEnvironmentVariable("DATABASE_URL", EnvironmentVariableTarget.Machine);
            }

            //databaseURL = "postgres://kryehtqiidkqvy:e5a447d39798c42b0aeb207a7de70ccef1270a63514f3f3528d16a07a2d3314e@ec2-79-125-4-96.eu-west-1.compute.amazonaws.com:5432/d71u6lnl5f5l41";

            var builder = new PostgreSqlConnectionStringBuilder(databaseURL)
            {
                Pooling = true,
                TrustServerCertificate = true,
                SslMode = SslMode.Prefer
            };

            return builder.ToString();
        }

    }
}
