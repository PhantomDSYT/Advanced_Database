using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class EmployeeAudit
    {
        public int Trn { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public long? Tel { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditDate { get; set; }
    }
}
