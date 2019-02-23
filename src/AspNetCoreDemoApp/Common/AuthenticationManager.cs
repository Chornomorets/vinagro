using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Common
{
    public class AuthenticationManager
    {

        private static string _authentication;

        public static bool IsAuthenticated(HttpRequest request)
        {
            var authorization = request.Headers["Authorization"].ToString();
            _authentication = _authentication == null ? EnvironmentConfigManager.GetAuthenticationString() : _authentication;
            return authorization == _authentication;
        }

        public static object UnauthorizedError()
        {
            return ErrorHandler.GenerateError(ErrorHandler.Unauthorized, ErrorHandler.Description(ErrorHandler.Unauthorized));
        }
    }
}
