using System.ComponentModel.DataAnnotations;

namespace ProjetoInterdisciplinar.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
    }
}
