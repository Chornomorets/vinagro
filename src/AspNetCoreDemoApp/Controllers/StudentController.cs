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
using Microsoft.AspNetCore.Mvc.Filters;
using AspNetCoreDemoApp.Repos;

namespace AspNetCoreDemoApp.Controllers
{

    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private StudentRepo _studentRepo = new StudentRepo();

        // POST: api/Student/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<Student> RegisterStudent([FromBody]Student student)
        {
            if (StudentValidator.IsUsernameExists(student))
            {
                return BadRequest(ErrorHandler.GenerateError(999, "Username already exists."));
            }

            _studentRepo.Create(student);

            return student;
        }

        // POST: api/Student/Retrieve
        [HttpPost]
        [Route("Retrieve")]
        public ActionResult<Student> RetrieveStudent([FromBody] AuthenticationParams model)
        {
            return _studentRepo.Find(model);
        }

        // POST: api/Student/RetrieveByToken
        [HttpPost]
        [Route("RetrieveByToken")]
        public ActionResult<Student> RetrieveByToken([FromBody]TokenParams token)
        {
            return _studentRepo.Find(token.Token);
        }

        // POST: api/Student/GenerateToken
        [HttpPost]
        [Route("GenerateToken")]
        public ActionResult<string> GenerateToken([FromBody]AuthenticationParams model)
        {
            return _studentRepo.SetToken(model);
        }

        // POST: api/Student/GetToken
        [HttpPost]
        [Route("GetToken")]
        public ActionResult<string> GetToken([FromBody]AuthenticationParams model)
        {
            return _studentRepo.GetToken(model);
        }
    }
}