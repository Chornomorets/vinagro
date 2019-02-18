using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Model
{
    public class AuthenticationModel
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(350)]
        public string Password { get; set; }
    }
}
