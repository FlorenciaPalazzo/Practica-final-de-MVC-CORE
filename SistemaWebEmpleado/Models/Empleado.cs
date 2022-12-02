using SistemaWebEmpleado.Validations;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string DNI { get; set; }

        [Required]
        [CheckLegajo]
        public string Legajo { get; set; }
        [Required]
        public string Titulo { get; set; }
    }
}

