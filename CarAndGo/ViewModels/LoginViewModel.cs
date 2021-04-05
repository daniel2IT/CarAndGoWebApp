using System.ComponentModel.DataAnnotations;

namespace CarAndGo.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        public string ReturnUrl { get; set; }

    }
}
