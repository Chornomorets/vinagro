using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Common
{
    public class AuthenticationManager
    {
        #region constants

        private static readonly int     ERROR_CODE_UNAUTHORIZED = 401;
        private static readonly string ERROR_DESCRIPTION_UNAUTHORIZED = "Invalid authentication credentials.";

        #endregion

        private static string _authentication;

        public static bool IsAuthenticated(HttpRequest request)
        {
            var authorization = request.Headers["Authorization"].ToString();
            _authentication = _authentication == null ? EnvironmentConfigManager.GetAuthenticationString() : _authentication;
            return authorization == _authentication;
        }

        public static object UnauthorizedError()
        {
            return ErrorHandler.GenerateError(ERROR_CODE_UNAUTHORIZED, ERROR_DESCRIPTION_UNAUTHORIZED);
        }
    }
}
