using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validations
{
    public class CheckLegajo :ValidationAttribute
    {
        public CheckLegajo()
        {
            ErrorMessage = "El legajo comienza con dos letras “AA” y luego 5 números.";
        }
        public override bool IsValid(object value)
        {
            string legajo = Convert.ToString(value);
            legajo.Replace(" ", "");
           
            if (legajo.Substring(0, 2) == "AA" && int.TryParse(legajo.Replace("AA", ""), out int numLegajo) && legajo.Replace("AA", "").Length == 5)
            {
              
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
