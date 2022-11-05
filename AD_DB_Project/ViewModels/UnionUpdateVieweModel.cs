using System.ComponentModel.DataAnnotations;

namespace AD_DB_Project.ViewModels
{
    public class UnionUpdateVieweModel
    {
        public int Trn { get; set; }
        [Display(Name ="Union Membership")]
        public string Membership { get; set; }
    }
}
