using AspNetCoreDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Validators
{
    public class PartnerValidator
    {
        public static bool IsUsernameExists(Partner partner)
        {
            using(var context = new Context())
            {
                return context.Partner.Where(p => p.Username == partner.Username)
                                       .Any();
            }           
        }
    }
}
