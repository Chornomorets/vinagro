using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Model
{
    public class MentorRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, ForeignKey("Mentor")]
        public long FK_Mentor { get; set; }
        public Mentor Mentor { get; set; }

        [Required, ForeignKey("Project")]
        public long FK_Project { get; set; }
        public Project Project { get; set; }

        [Required]
        public DateTime CreatedTime { get; set; }

        [Required]
        public int State { get; set; }
    }
}
