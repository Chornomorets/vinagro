using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class MentorRequestValidator
    {
        public static Context _context = new Context();

        public static bool IsExistsRequest(MentorRequestParams requestParams)
        {
            return _context.MentorRequest.Where(r => r.FK_Mentor == requestParams.MentorID && r.FK_Project == requestParams.ProjectID)
                                         .Any();
        }

    }
}
