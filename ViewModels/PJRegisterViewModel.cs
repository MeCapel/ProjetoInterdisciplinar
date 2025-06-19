using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProjetoInterdisciplinar.ViewModels
{
    [Index("Email", IsUnique = true)]
    [Index("CNPJ", IsUnique = true)]
    public class PJRegisterViewModel
    {
        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Entre 2 - 35 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras")]
        [Display(Name = "Nome")]
        public string Name { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(14, ErrorMessage = "Deve conter 14 careacteres")]
        [RegularExpression(@"^-?[0-9][0-9,\.]+$", ErrorMessage = "Somente numeros")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }




        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Entre 2 - 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras")]
        [Display(Name = "Ramo")]
        public string Ramo { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(75, ErrorMessage = "Até 75 caracteres")]
        [Display(Name = "Email"), EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Insira um Email válido.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Entre 8-25 caracteres")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Compare("Password", ErrorMessage = "As senhas estão diferentes")]
        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
