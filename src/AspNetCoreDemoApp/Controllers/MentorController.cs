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
    [Route("api/Mentor")]
    public class MentorController : ControllerBase
    {
        private readonly Context _context = new Context();

        // POST: api/Mentor/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<Mentor> RegisterMentor([FromBody]Mentor mentor)
        {
            var mentors = _context.Mentor;
            if (MentorValidator.IsUsernameExists(mentor))
            {
                return BadRequest(ErrorHandler.GenerateError(999, "Username already exists."));
            }
            mentors.Add(mentor);
            _context.SaveChanges();
            return mentor;
        }

        // POST: api/Student/Retrieve
        [HttpPost]
        [Route("Retrieve")]
        public ActionResult<Mentor> RetrieveMentor([FromBody] AuthenticationModel model)
        {
            var mentor = _context.Mentor.Where(m => m.Username == model.Username && m.Password == model.Password)
                                          .FirstOrDefault();
            return mentor;
        }
    }
}