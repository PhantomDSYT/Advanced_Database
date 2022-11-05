using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class Airport
    {
        public Airport()
        {
            Airplane = new HashSet<Airplane>();
            WorkStaff = new HashSet<WorkStaff>();
        }

        [Display(Name = "Airport Code")]
        [Required(ErrorMessage = "Enter a code")]
        public string AirportCode { get; set; }

        [Display(Name = "Airport Name")]
        [Required(ErrorMessage = "Enter a name")]
        public string AirportName { get; set; }

        [Display (Name = "Airport Parish")]
        [Required(ErrorMessage = "Enter a parish")]
        public string AirportParish { get; set; }

        [Display (Name = "Airport City")]
        [Required(ErrorMessage = "Enter a city")]
        public string AirportCity { get; set; }

        public virtual ICollection<Airplane> Airplane { get; set; }
        public virtual ICollection<WorkStaff> WorkStaff { get; set; }
    }
}
