using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AD_DB_Project.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
