using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class Airplane
    {
        public Airplane()
        {
            Test = new HashSet<Test>();
        }

        [Display(Name ="Regulation Number")]
        [Required(ErrorMessage = "Enter Regulation Number")]
        public int RegNum { get; set; }

        [Required(ErrorMessage = "Enter Company Name")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Enter Plane Model")]
        public string Model { get; set; }

        [Display(Name = "Airport Code")]
        [Required(ErrorMessage = "Enter an Airport Code")]
        public string AirportCode { get; set; }

        [Display(Name = "Airport Code")]
        public virtual Airport AirportCodeNavigation { get; set; }
        public virtual ICollection<Test> Test { get; set; }
    }
}
