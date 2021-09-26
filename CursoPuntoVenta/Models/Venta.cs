using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Models
{
    public class Venta
    {
        public int? Id { get; set; }
        public int Id_empleado { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int id_cliente { get; set; }
        public int PuntosGenerados { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
