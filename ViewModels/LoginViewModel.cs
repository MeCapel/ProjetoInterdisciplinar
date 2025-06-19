using System.ComponentModel.DataAnnotations;

namespace ProjetoInterdisciplinar.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(26, ErrorMessage = "Até 25 caracteres")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name = "Lembre-se de mim")]
        public bool RememberMe { get; set; }
    }
}
