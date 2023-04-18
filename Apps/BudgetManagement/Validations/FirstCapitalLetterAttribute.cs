using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Validations
{
    public class FirstCapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // valor -> campo del modelo
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firtsLetter = value.ToString()[0].ToString();

            //Validamos si la primera letra es mayuscula 
            if(firtsLetter != firtsLetter.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayuscula...");
            }

            return ValidationResult.Success;
        }
    }
}

//Crearemos nuestras propias validaciones 
//    en este caso que la primera letra sea mayuscula 