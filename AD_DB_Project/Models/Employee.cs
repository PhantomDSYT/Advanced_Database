using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Category = new HashSet<Category>();
            Supervisor = new HashSet<Supervisor>();
            WorkStaff = new HashSet<WorkStaff>();
            WorkerUnion = new HashSet<WorkerUnion>();
        }

        [Display(Name = "TRN")]
        public int Trn { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        public decimal? Salary { get; set; }

        public string Address { get; set; }

        [Display(Name = "Telephone Number")]
        public long? Tel { get; set; }

        public virtual Technician Technician { get; set; }
        public virtual TrafficController TrafficController { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Supervisor> Supervisor { get; set; }
        public virtual ICollection<WorkStaff> WorkStaff { get; set; }
        public virtual ICollection<WorkerUnion> WorkerUnion { get; set; }
    }
}
