using System.ComponentModel.DataAnnotations;

namespace ProjetoInterdisciplinar.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(75, ErrorMessage = "Até 75 caracteres")]
        [Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Entre 8-25 caracteres")]
        [Display(Name = "Nova senha")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Compare("NewPassword", ErrorMessage = "As senhas estão diferentes")]
        [Display(Name = "Confirme a nova senha")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
