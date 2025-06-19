using System.ComponentModel.DataAnnotations;

namespace ProjetoInterdisciplinar.CustomStuffs
{
    public class ValidDate : ValidationAttribute
    {

        private const int MinimumAge = 14;

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateOnly date)
            {
                return new ValidationResult("Data inválida");
            }

            var today = DateOnly.FromDateTime(DateTime.Today); 

            if (date > today)
            {
                return new ValidationResult("Data de nascimento nã pode ser no futuro");
            }

            if (date.Year < 1000 || date.Year > 9999)
            {
                return new ValidationResult("O ano deve conter exatamente 4 digitos");
            }

            var age = today.Year - date.Year;
            if (date > today.AddYears(-age)) age--;

            if (age < MinimumAge)
                return new ValidationResult($"Você deve ter pelo menos {MinimumAge} anos");


            return ValidationResult.Success!;
        }
    }
}
