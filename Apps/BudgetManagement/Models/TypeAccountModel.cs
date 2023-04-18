using BudgetManagement.Controllers;
using BudgetManagement.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models
{
    public class TypeAccountModel// : IValidatableObject
    {
        public int Id { get; set; }

        //Validacion por atributo
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe de estar ebte {2} y {1}")]
        [Required(ErrorMessage = "El campo {0} es requerido")] //Mensaje de  error, {0} se concatena la propiedad
        [Display(Name = "Nombre del Tipo de Cuenta")]
        [FirstCapitalLetter]
        [Remote(action: "VerifyExistenceTypeAccount", controller: "TypeAccount")] //=> validacion remota desde un controlador 
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Orden { get; set; }


        //Validacion por modelo
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(Name != null && Name.Length > 0)
        //    {
        //        var firtsLetter = Name[0].ToString();

        //        //Validamos si la primera letra es mayuscula 
        //        if (firtsLetter != firtsLetter.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula...", new[] {nameof(Name)});
        //            //nameof(Name) => especifica el nombre 

        //            //yield return new ValidationResult("La primera letra debe ser mayuscula..." });
        //            // error a nivel de modelo
        //        }

        //    }
        //}
    }
}
