using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobsIE.Models
{
    public class CVFile
    {
        [Key, ForeignKey("JobSeekerUser")]
        public int JobSeekerUserID { get; set; }
        public string Filename { get; set; }
        public byte[] FileContent { get; set; }
         
        public DateTime? FileLastUpdated { get; set; }        
        public virtual JobSeekerUser JobSeekerUser { get; set; }
    }
}