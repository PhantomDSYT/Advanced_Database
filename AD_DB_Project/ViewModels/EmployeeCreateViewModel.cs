using System;
using System.ComponentModel.DataAnnotations;

namespace AD_DB_Project.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Please enter an employee TRN")]
        [Display(Name = "TRN")]
        public int Trn { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a last name")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a middle name")]
        [Display(Name = "Middle Name")]
        public string MName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please enter the salary")]
        public decimal? Salary { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter an address")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter a phone number")]
        [Display(Name = "Telephone Number")]
        public long? Tel { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter an airport code")]
        [Display(Name = "Airport Code")]
        public string AirportCode { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an employee role")]
        [Display(Name = "Employee Role")]
        public string EmployeeRole { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select an expertise")]
        [Display(Name = "Technician Expertise")]
        public string TechExpertise { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please select a restriction")]
        [Display(Name = "Technician Restriction")]
        public string TechRestriction { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please select an exam date")]
        [Display(Name = "Exam Date")]
        public DateTime ExamDate { get; set; }
    }
}
