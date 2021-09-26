using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Models
{
    public class Empleados : Persona
    {            
        public Sucursal Sucursal { get; set; }
    }
}
