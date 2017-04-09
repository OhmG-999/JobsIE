using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsIE.Models
{
    public class JobApplication
    {
        // Composite Primary Key
        [Key, ForeignKey("Job")]
        [Column(Order = 1)]
        public int JobID { get; set; }

        [Key, ForeignKey("JobSeekerUser")]
        [Column(Order = 2)]
        public int JobSeekerID { get; set; }

        public bool Applied { get; set; }
        public string JobApplicationStatus { get; set; }
        public DateTime ApplicationDate { get; set; }

        // Navigational Properties 
        public virtual Job Job { get; set; }
        public virtual JobSeekerUser JobSeekerUser { get; set; }
    }
}