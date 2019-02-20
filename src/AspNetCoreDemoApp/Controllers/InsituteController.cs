using AspNetCoreDemoApp.Common;
using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Controllers
{
    [Route("api/Institute")]
    public class InsituteController : ControllerBase
    {
        private readonly Context _context = new Context();

        // POST: api/Institute/Add
        [HttpPost]
        [Route("Add")]
        public ActionResult<Institute> AddInstitute([FromBody]Institute institute)
        {
            var institutes = _context.Institute;

            if (InstituteValidator.IsInstituteExists(institute))
            {
                return BadRequest(ErrorHandler.GenerateError(1201, "Institute already exists."));
            }

            institutes.Add(institute);
            _context.SaveChanges();
            return institute;
        }
    }
}
