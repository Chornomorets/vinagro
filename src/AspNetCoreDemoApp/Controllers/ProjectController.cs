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
    [Route("api/Project")]
    public class ProjectController : ControllerBase
    {
        private readonly Context _context = new Context();

        // POST: api/Project/Add
        [HttpPost]
        [Route("Add")]
        public ActionResult<Project> AddProject([FromBody]Project project)
        {
            var projects = _context.Project;

            if (ProjectValidator.IsProjectNameExists(project))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.ProjectNameEsists));
            }

            projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        // POST: api/Project/All
        [HttpGet]
        [Route("All")]
        public ActionResult<Project[]> AllProjects()
        {
            return _context.Project.ToArray();
        }


    }
}
