using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class ProjectValidator
    {
        private static Context _context = new Context();

        public static bool IsProjectNameExists(Project project)
        {
            using (var context = new Context())
            {
                return context.Project.Where(p => p.Name == project.Name)
                                       .Any();
            }
        }

        public static bool IsProjectExists(long id)
        {
            return _context.Project.Find(id) != null;
        }
    }
}
