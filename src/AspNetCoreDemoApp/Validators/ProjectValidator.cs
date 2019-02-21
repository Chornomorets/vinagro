using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class ProjectValidator
    {
        public static bool IsProjectNameExists(Project project)
        {
            using (var context = new Context())
            {
                return context.Project.Where(p => p.Name == project.Name)
                                       .Any();
            }
        }
    }
}
