using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class WorkerUnion
    {
        public WorkerUnion()
        {
            Category = new HashSet<Category>();
        }

        [Display(Name = "Union Membership")]
        [Required(ErrorMessage ="Enter Union Membership")]
        public string UMembership { get; set; }

        [Display(Name = "Union Name")]
        [Required(ErrorMessage = "Enter Union Name")]
        public string UName { get; set; }

        [Display(Name = "Union President")]
        [Required(ErrorMessage = "Select a Union President")]
        public int? UPresident { get; set; }

        [Display(Name = "Union President")]
        public virtual Employee UPresidentNavigation { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
