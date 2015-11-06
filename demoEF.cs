using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Ejercicio001
{
   public class demoEF:DbContext
    {
       public DbSet<Empleado> Empleados { get; set; }
       public DbSet<Departamento> Departamentos { get; set; }
    }
}
