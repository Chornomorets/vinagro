using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Repos
{
    public class MentorRequestRepo
    {
        private class RequestState
        {
            public const int Created = 1;
            public const int Accepted = 2;
            public const int Denied = 0;
        }

        private readonly Context _context = new Context();

        public MentorRequest CreateRequest(MentorRequestParams requestParams)
        {
            var mentorRequest = new MentorRequest
            {
                FK_Mentor = requestParams.MentorID,
                FK_Project = requestParams.ProjectID,
                CreatedTime = DateTime.Now,
                State = RequestState.Created
            };

            _context.MentorRequest.Add(mentorRequest);
            _context.SaveChanges();

            return mentorRequest;
        }

        public MentorRequest AcceptRequest(MentorRequestParams requestParams)
        {
            var mr = Find(requestParams);

            mr.State = RequestState.Accepted;

            _context.SaveChanges();

            return mr;
        }

        public MentorRequest Find(MentorRequestParams requestParams)
        {

            return _context.MentorRequest
                             .Where(r => r.FK_Project == requestParams.ProjectID && r.FK_Mentor == requestParams.MentorID)
                             .FirstOrDefault();
        }

        public MentorRequest DenyRequest(MentorRequestParams requestParams)
        {
            var mr = Find(requestParams);

            mr.State = RequestState.Denied;

            _context.SaveChanges();

            return mr;
        }
    }
}
