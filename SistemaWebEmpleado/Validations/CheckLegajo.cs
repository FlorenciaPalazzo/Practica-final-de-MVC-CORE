using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            string check = value as string;

            if (value == null)
            {
                return false;
            }
            else

            if (check.Length != 7)
            {
                return false;
            }
            else
            {
                if (check[0] == 'A' && check[1] == 'A')
                {
                    string resultString = Regex.Match(check, @"\d+").Value;
                    if (resultString.Length == 5)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
