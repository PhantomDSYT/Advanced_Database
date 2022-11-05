using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class Category
    {
        public string UMembership { get; set; }

        public int Trn { get; set; }

        public virtual Employee TrnNavigation { get; set; }
        public virtual WorkerUnion UMembershipNavigation { get; set; }
    }
}
