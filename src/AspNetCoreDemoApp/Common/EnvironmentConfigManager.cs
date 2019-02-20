using Common.AspNetCoreDemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Common
{
    public static class EnvironmentConfigManager
    {
        #region constants

        private static readonly string DATABASE_URL = "DATABASE_URL";
        private static readonly string AUTHORIZATION = "AUTHORIZATION";

        #endregion

        public static string GetConnectionString()
        {
            var builder = new PostgreSqlConnectionStringBuilder(GetEnvironmentVariable(DATABASE_URL))
            {
                Pooling = true,
                TrustServerCertificate = true,
                SslMode = SslMode.Prefer
            };

            return builder.ToString();
        }

        public static string GetAuthenticationString()
        {
            return GetEnvironmentVariable(AUTHORIZATION);
        }

        private static string GetEnvironmentVariable(string key)
        {
            //if run at the heroku
            var authentication = Environment.GetEnvironmentVariable(key);

            //if run at the local
            if (authentication == null)
            {
                authentication = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);
            }

            return authentication;
        }
    }
}
