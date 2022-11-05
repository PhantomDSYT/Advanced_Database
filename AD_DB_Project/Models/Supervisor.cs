using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class Supervisor
    {
        [Display(Name ="TRN")]
        public int Trn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Start Date")]
        [Required(ErrorMessage ="Enter a start date")]
        public DateTime Start { get; set; }

        [Display(Name = "Supervisee")]
        public int Employee { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "TRN")]
        public virtual Employee TrnNavigation { get; set; }
    }
}
