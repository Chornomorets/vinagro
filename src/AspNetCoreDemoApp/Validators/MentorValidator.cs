using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class MentorValidator
    {
        private readonly Context _context;
        public static bool IsUsernameExists(Mentor mentor)
        {
            using(var context = new Context())
            {
                return context.Mentor.Where(m => m.Username == mentor.Username)
                                       .Any();
            }           
        }
    }
}
