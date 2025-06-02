using System.ComponentModel.DataAnnotations;

namespace ProjetoInterdisciplinar.ViewModels
{
    public class PJDtoViewModel
    {
        public string Id { get; set; }


        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Entre 2 - 35 caracteres")]
        [Display(Name = "Nome")]
        public string Name { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(14, ErrorMessage = "Deve conter 14 careacteres")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Entre 2 - 35 caracteres")]
        [Display(Name = "Ramo")]
        public string Ramo { get; set; }



        [Display(Name = "Habilitado(a)")]
        public bool Able { get; set; }
    }
}
