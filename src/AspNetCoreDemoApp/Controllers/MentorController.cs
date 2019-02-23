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
using AspNetCoreDemoApp.Repos;
using AspNetCoreDemoApp.Model.Params;

namespace AspNetCoreDemoApp.Controllers
{
    [Route("api/Mentor")]
    public class MentorController : ControllerBase
    {
        private MentorRepo _mentorRepo = new MentorRepo();

        private MentorRequestRepo _mentorRequestRepo = new MentorRequestRepo();

        // POST: api/Mentor/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<Mentor> RegisterMentor([FromBody]Mentor mentor)
        {
            if (MentorValidator.IsUsernameExists(mentor))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.UsernameExists));
            }

            _mentorRepo.Create(mentor);

            return mentor;
        }

        // POST: api/Mentor/Retrieve
        [HttpPost]
        [Route("Retrieve")]
        public ActionResult<Mentor> RetrieveMentor([FromBody] AuthenticationParams model)
        {
            return _mentorRepo.Find(model);
        }

        // POST: api/Mentor/RetrieveByToken
        [HttpPost]
        [Route("RetrieveByToken")]
        public ActionResult<Mentor> RetrieveByToken([FromBody]TokenParams token)
        {
            return _mentorRepo.Find(token.Token);
        }

        // POST: api/Mentor/GenerateToken
        [HttpPost]
        [Route("GenerateToken")]
        public ActionResult<string> GenerateToken([FromBody]AuthenticationParams model)
        {
            return _mentorRepo.SetToken(model);
        }

        // POST: api/Mentor/GetToken
        [HttpPost]
        [Route("GetToken")]
        public ActionResult<string> GetToken([FromBody]AuthenticationParams model)
        {
            return _mentorRepo.GetToken(model);
        }

        // POST: api/Mentor/CreateRequest
        [HttpPost]
        [Route("CreateRequest")]
        public ActionResult<MentorRequest> CreateRequest([FromBody]MentorRequestParams requestParams)
        {

            if (!MentorValidator.IsMentorExists(requestParams.MentorID))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.MentorNotFound));
            }

            if (!ProjectValidator.IsProjectExists(requestParams.ProjectID))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.ProjectNotFound));
            }

            if (MentorRequestValidator.IsExistsRequest(requestParams))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.MentorRequestExists));
            }

            return _mentorRequestRepo.CreateRequest(requestParams);
        }

    }
}