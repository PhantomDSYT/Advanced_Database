using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AD_DB_Project.Models
{
    public partial class Test
    {
        [Display(Name ="FAA Number")]
        [Required(ErrorMessage ="Enter FAA Number")]
        public int FaaNum { get; set; }

        [Display(Name ="Test Name")]
        public string Name { get; set; }

        [Display(Name ="Max Score")]
        [Required(ErrorMessage = "Enter max score")]
        public int? MaxScore { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter a date")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Enter score")]
        public int? Score { get; set; }

        [Display(Name = "Test Hours")]
        [Required(ErrorMessage = "Enter hours to complete")]
        public int? TestHours { get; set; }

        [Display(Name = "Regulation Numbers")]
        public int? RegNum { get; set; }

        [Display(Name = "Regulation Numbers")]
        public virtual Airplane RegNumNavigation { get; set; }
    }
}
