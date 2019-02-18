using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Model
{
    public class Mentor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        public string Description { get; set; }

        [MaxLength(100)]
        public string Photo { get; set; }

        [Required, ForeignKey("Institute")]
        public long FK_Intitute { get; set; }
        public Institute Institute { get; set; }

        [Required, MaxLength(50)]
        public string Position { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(350)]
        public string Password { get; set; }
    }
}
