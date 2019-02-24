using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemoApp.Model
{
    public class Student2Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, ForeignKey("Student")]
        public long FK_Student { get; set; }
        public Student Student { get; set; }

        [Required, ForeignKey("Project")]
        public long FK_Project { get; set; }
        public Project Project { get; set; }
    }
}
