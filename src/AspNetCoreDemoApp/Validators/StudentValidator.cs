using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class StudentValidator
    {
        private readonly Context _context;
        public static bool IsUsernameExists(Student student)
        {
            using(var context = new Context())
            {
                return context.Student.Where(s => s.Username == student.Username)
                                       .Any();
            }           
        }
    }
}
