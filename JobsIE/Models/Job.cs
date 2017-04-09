using JobsIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsIE.Models
{
    //  partial class Job
    public class Job
    {
        public int JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobSalaryRange { get; set; }
        public string JobHours { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool JobOnline { get; set; }
        public string Location { get; set; }
        public string JobBenefits { get; set; }
        public string JobRequirements { get; set; }

        public int CompanyID  { get; set; }       
        public virtual IEnumerable<JobApplication> JobApplication { get; set; }

        //public Location Location { get; set; }
    }


   // public enum Location { Dublin, Limerick, Galway }


}