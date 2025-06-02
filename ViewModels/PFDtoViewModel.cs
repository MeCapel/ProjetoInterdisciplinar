using System.ComponentModel.DataAnnotations;

namespace ProjetoInterdisciplinar.ViewModels
{
    public class PFDtoViewModel
    {
        public string Id { get; set; }


        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Entre 2 - 35 caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Entre 2 - 50 caracteres")]
        [Display(Name = "Sobrenome")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Display(Name = "Data de nascimento")]
        public DateOnly BirthDate { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Display(Name = "Sexo")]
        public string Sex { get; set; }


        [Display(Name = "Habilitado(a)")]
        public bool Able { get; set; }
    }
}
