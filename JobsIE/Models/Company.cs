using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsIE.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public int CompanyCredCardNumber { get; set; }
        public int CompanyCCVNumber { get; set; }
        public DateTime CredCardExpiryDate { get; set; }

        public DateTime SubscriptionExpiryDate { get; set; }
        public bool EmailSubscriptionSent { get; set; }
        public DateTime LastLoginDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual IEnumerable<Job> Jobs { get; set; }

    }
}