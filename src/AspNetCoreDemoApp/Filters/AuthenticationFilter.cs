using AspNetCoreDemoApp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Filters
{

    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!AuthenticationManager.IsAuthenticated(context.HttpContext.Request))
            {
                context.Result = new BadRequestObjectResult(AuthenticationManager.UnauthorizedError());
            }
        }

    }
}
