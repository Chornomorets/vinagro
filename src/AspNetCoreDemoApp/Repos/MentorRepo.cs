using AspNetCoreDemoApp.Common;
using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Repos
{
    public class MentorRepo
    {
        private readonly Context _context = new Context();
        public Mentor Find(AuthenticationParams model)
        {
            var mentor = _context.Mentor.Where(m => m.Username == model.Username && m.Password == model.Password)
                              .FirstOrDefault();
            return mentor;
        }

        public Mentor Find(string token)
        {
            var mentor = _context.Mentor.Where(m => m.Token == token)
                .FirstOrDefault();
            return mentor;
        }

        public Mentor Create(Mentor mentor)
        {
            var mentors = _context.Mentor;
            mentor.Token = Guid.NewGuid().ToString();
            mentors.Add(mentor);
            _context.SaveChanges();
            return mentor;
        }

        public string SetToken(AuthenticationParams model)
        {
            var mentor = Find(model);

            if (mentor != null)
            {
                mentor.Token = Guid.NewGuid().ToString();
                _context.SaveChanges();
            }
            return mentor?.Token;
        }

        public string GetToken(AuthenticationParams model)
        {
            return Find(model).Token;
        }
    }
}
