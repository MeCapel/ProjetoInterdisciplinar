using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProjetoInterdisciplinar.ViewModels
{
    public class VagaDtoViewModel
    {
        [Required(ErrorMessage = "Este campo é necessário")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Entre 2 - 50 caracteres")]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }



        //[Required(ErrorMessage = "Este campo é necessário")]
        //[StringLength(75, MinimumLength = 2, ErrorMessage = "Entre 2 - 75 caracteres")]
        //[Display(Name = "Descrição")]
        //public string Descricao { get; set; }



        [Display(Name = "Salário")]
        [Range(1, double.MaxValue, ErrorMessage = "O salário deve ser maior que 0")]
        public decimal? Salario { get; set; }
    }
}
