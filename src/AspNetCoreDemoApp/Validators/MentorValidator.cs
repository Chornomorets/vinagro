using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class MentorValidator
    {
        private static Context _context = new Context();

        public static bool IsUsernameExists(Mentor mentor)
        {
                return _context.Mentor.Where(m => m.Username == mentor.Username)
                                      .Any();
        }

        internal static bool IsMentorExists(long id)
        {
            return _context.Mentor.Find(id) != null;
        }
    }
}
