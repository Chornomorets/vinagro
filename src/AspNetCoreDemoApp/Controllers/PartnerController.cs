using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreDemoApp.Common;
using AspNetCoreDemoApp.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web.Http;
using AspNetCoreDemoApp.Validators;

namespace AspNetCoreDemoApp.Controllers
{
    [Route("api/Partner")]
    public class PartnerController : ControllerBase
    {
        private readonly Context _context = new Context();

        // POST: api/Partner/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<Partner> RegisterPartner([FromBody]Partner partner)
        {
            var partners = _context.Partner;

            if (PartnerValidator.IsUsernameExists(partner))
            {
                return BadRequest(ErrorHandler.GenerateError(999, "Username already exists."));
            }
            partners.Add(partner);
            _context.SaveChanges();
            return partner;
        }

        // POST: api/Partner/Retrieve
        [HttpPost]
        [Route("Retrieve")]
        public ActionResult<Partner> RetrievePartner([FromBody] AuthenticationModel model)
        {
            var partner = _context.Partner.Where(p => p.Username == model.Username && p.Password == model.Password)
                                          .FirstOrDefault();
            return partner;
        }
    }
}