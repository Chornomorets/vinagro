using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class InstituteValidator
    {

        public static bool IsInstituteExists(Institute institute)
        {
            using (var context = new Context())
            {
                return context.Institute.Where(i => i.Name == institute.Name)
                                       .Any();
            }
        }


    }
}
