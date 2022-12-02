using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoContext :DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options): base(options){}
        public DbSet<Empleado> Empleados { get; set; }
    }
}
