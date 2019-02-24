using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Model.Params;

namespace AspNetCoreDemoApp.Repos
{
    public class ProjectRepo
    {
        Context _context = new Context();

        public bool AddMentorOnProject(MentorRequestParams requestParams)
        {
            var project = _context.Project.Find(requestParams.ProjectID);

            project.FK_Mentor = requestParams.MentorID;
            _context.SaveChanges();

            return true;
        }
    }
}
