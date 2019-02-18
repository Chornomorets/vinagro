using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Model
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("Mentor")]
        public long FK_Mentor { get; set; }
        public Mentor Mentor { get; set; }

        [Required, ForeignKey("Partner")]
        public long FK_Partner { get; set; }
        public Partner Partner { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, MaxLength(50)]
        public string ProjectCategory { get; set; }

        public int Duration { get; set; }
    }
}
