﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ProjetoInterdisciplinar.CustomStuffs;

namespace ProjetoInterdisciplinar.ViewModels
{
    [Index("Email", IsUnique = true)]

    public class PFRegisterViewModel
    {
        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Entre 2 - 35 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras")]
        [Display(Name = "Nome")]
        public string Name { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(51, MinimumLength = 2, ErrorMessage = "Entre 2 - 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Somente letras")]
        [Display(Name = "Sobrenome")]
        public string Surname { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Insira um data válida e existente")]
        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Display(Name = "Data de nascimento")]
        // custom validation
        [ValidDate]
        public DateOnly BirthDate { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [Display(Name = "Sexo")]
        public string Sex { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(76, ErrorMessage = "Até 75 caracteres")]
        [Display(Name = "Email"), EmailAddress]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Insira um Email válido.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "O seguinte campo é necessário")]
        [StringLength(26, MinimumLength = 8, ErrorMessage = "Entre 8-25 caracteres")]
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
