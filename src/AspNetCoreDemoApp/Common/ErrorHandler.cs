using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace AspNetCoreDemoApp.Common
{
    public class ErrorHandler
    {

        #region consts

        public const int Unhandled = 999;

        public const int Unauthorized = 401;

        public const string description401 = "Invalid authentication credentials.";

        public const int UsernameExists = 1001;
        public const string description1001 = "Username already exists.";


        #region Mentor

        public const int MentorNotFound = 3001;
        public const string description3001 = "Mentor not found.";
        #endregion

        #region Project

        public const int ProjectNotFound = 4001;
        public const string description4001 = "Project not found.";
        
        public const int ProjectNameEsists = 4002;
        public const string description4002 = "Project name already exists.";
        #endregion

        #region MentorRequest

        public const int MentorRequestDoesNotExists = 8001;
        public const string description8001 = "Mentor request for this project and mentor not found.";

        public const int MentorRequestExists = 8002;
        public const string description8002 = "Mentor request for this project and mentor already exists.";

        #endregion

        #endregion

        public static Object GenerateError(int error, string description) {
            return new
            {
                Code = error,
                Description = description
            };
        }

        public static Object GenerateError(int error)
        {
            return new
            {
                Code = error,
                Description = Description(error)
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

        public static string Description(int code)
        {
            var s = typeof(ErrorHandler).GetField("description" + code)?.GetValue(null);

            if (s is string)
            {
                return (string) s;
            }
            return null;
        }

    }
}
