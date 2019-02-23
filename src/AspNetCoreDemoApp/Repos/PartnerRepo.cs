using AspNetCoreDemoApp.Common;
using AspNetCoreDemoApp.Model;
using AspNetCoreDemoApp.Model.Params;
using AspNetCoreDemoApp.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Repos
{
    public class PartnerRepo
    {
        private readonly Context _context = new Context();
        public Partner Find(AuthenticationParams model)
        {
            var partner = _context.Partner.Where(p => p.Username == model.Username && p.Password == model.Password)
                              .FirstOrDefault();
            return partner;
        }

        public Partner Find(string token)
        {
            var partner = _context.Partner.Where(p => p.Token == token)
                .FirstOrDefault();
            return partner;
        }

        public Partner Create(Partner partner)
        {
            var partners = _context.Partner;
            partner.Token = Guid.NewGuid().ToString();
            partners.Add(partner);
            _context.SaveChanges();
            return partner;
        }

        public string SetToken(AuthenticationParams model)
        {
            var partner = Find(model);

            if (partner != null)
            {
                partner.Token = Guid.NewGuid().ToString();
                _context.SaveChanges();
            }
            return partner?.Token;
        }

        public string GetToken(AuthenticationParams model)
        {
            return Find(model).Token;
        }
    }
}
