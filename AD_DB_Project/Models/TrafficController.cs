using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class TrafficController
    {
        public int Trn { get; set; }
        public DateTime Exam { get; set; }

        public virtual Employee TrnNavigation { get; set; }
    }
}
