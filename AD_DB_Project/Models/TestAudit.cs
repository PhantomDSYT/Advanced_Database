using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class TestAudit
    {
        public int FaaNum { get; set; }
        public string Name { get; set; }
        public int? MaxScore { get; set; }
        public DateTime? Date { get; set; }
        public int? Score { get; set; }
        public int? TestHours { get; set; }
        public int? RegNum { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditDate { get; set; }
    }
}
