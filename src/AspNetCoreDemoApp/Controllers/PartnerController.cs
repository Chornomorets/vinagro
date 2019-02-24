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
    [Route("api/Partner")]
    public class PartnerController : ControllerBase
    {

        private PartnerRepo _partnerRepo = new PartnerRepo();

        private ProjectRepo _projectRepo = new ProjectRepo();

        private MentorRequestRepo _mentorRequestRepo = new MentorRequestRepo();

        // POST: api/Partner/Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<Partner> RegisterPartner([FromBody]Partner partner)
        {
            if (PartnerValidator.IsUsernameExists(partner))
            {
                return BadRequest(ErrorHandler.GenerateError(999, "Username already exists."));
            }

            _partnerRepo.Create(partner);

            return partner;
        }

        // POST: api/Partner/Retrieve
        [HttpPost]
        [Route("Retrieve")]
        public ActionResult<Partner> RetrievePartner([FromBody] AuthenticationParams model)
        {
            return _partnerRepo.Find(model);
        }

        // POST: api/Partner/RetrieveByToken
        [HttpPost]
        [Route("RetrieveByToken")]
        public ActionResult<Partner> RetrieveByToken([FromBody]TokenParams token)
        {
            return _partnerRepo.Find(token.Token);
        }

        // POST: api/Partner/GenerateToken
        [HttpPost]
        [Route("GenerateToken")]
        public ActionResult<string> GenerateToken([FromBody]AuthenticationParams model)
        {
            return _partnerRepo.SetToken(model);
        }

        // POST: api/Partner/GetToken
        [HttpPost]
        [Route("GetToken")]
        public ActionResult<string> GetToken([FromBody]AuthenticationParams model)
        {
            return _partnerRepo.GetToken(model);
        }

        // POST: api/Partner/AcceptMentor
        [HttpPost]
        [Route("AcceptMentor")]
        public ActionResult<MentorRequest> AcceptMentor([FromBody]MentorRequestParams requestParams)
        {
            if (!MentorRequestValidator.IsExistsRequest(requestParams))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.MentorRequestDoesNotExists));
            }

            _projectRepo.AddMentorOnProject(requestParams);
            return _mentorRequestRepo.ChangeState(requestParams, RequestState.Accepted);
        }
        // POST: api/Partner/DenyMentor
        [HttpPost]
        [Route("DenyMentor")]
        public ActionResult<MentorRequest> DenyMentor([FromBody]MentorRequestParams requestParams)
        {
            if (!MentorRequestValidator.IsExistsRequest(requestParams))
            {
                return BadRequest(ErrorHandler.GenerateError(ErrorHandler.MentorRequestDoesNotExists));
            }

            return _mentorRequestRepo.ChangeState(requestParams, RequestState.Denied);
        }
    }
}