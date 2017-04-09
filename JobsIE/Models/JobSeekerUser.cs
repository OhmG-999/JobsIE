using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsIE.Models
{
    public class JobSeekerUser
    {
        public int JobSeekerUserID { get; set; }

        public string JobSeekerName { get; set; }
        
        public string JobSeekerPhoneNumber { get; set; } // check User table
        public DateTime JobSeekerDoB { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string JobSeekerExpertise { get; set; }

        
        public virtual CVFile CVFiles { get; set; }
        public virtual ApplicationUser User { get; set; } //Identity User
        public virtual IEnumerable<JobApplication> JobApplications { get; set; }


    }
}