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

namespace AspNetCoreDemoApp.Controllers
{

    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private readonly Context _context = new Context();


        // POST: api/Student/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<Student> RegisterStudent([FromBody]Student student)
        {
            var students = _context.Student;

            if (StudentValidator.IsUsernameExists(student))
            {
                return BadRequest(ErrorHandler.GenerateError(999, "Username already exists."));
            }
            students.Add(student);
            _context.SaveChanges();
            return student;
        }

        // POST: api/Student/Retrieve
        [HttpPost]
        [Route("Retrieve")]
        public ActionResult<Student> RetrieveStudent([FromBody] AuthenticationParams model)
        {
            var student = _context.Student.Where(s => s.Username == model.Username && s.Password == model.Password)
                                          .FirstOrDefault();
            if(student == null)
                return BadRequest(ErrorHandler.GenerateError(1011, "Student with these parameters doesn't exist."));
            else
                return student;
        }
    }
}