using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Models
{
    public class Producto
    {
        public int? id { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public decimal precio { get; set; }
        public decimal Existencia { get; set; }
        public int? id_Sucursal { get; set; }
        public int? id_proveedor { get; set; }
    }
}
