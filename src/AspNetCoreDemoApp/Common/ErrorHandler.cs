using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Common
{
    public class ErrorHandler
    {
        public static Object GenerateError(int error, string description) {
            return new
            {
                Code = error,
                Description = description
            };
        }

        public static string MessageFromException(Exception e)
        {
            if (e.InnerException != null)
            {
                return e.InnerException.Message;
            }
            return e.Message;
        }
    }
}
