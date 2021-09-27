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
        public List<ListaVenta> Productos { get; set; }
        public Venta()
        {
            Productos = new List<ListaVenta>();
        }
        public class ListaVenta
        {
            public int? Id { get; set; }
            public Producto Producto { get; set; }
            public int cantidad { get; set; }
            public decimal subtotal { get; set; }
        }
        public void AggregarProducto(ListaVenta producto)
        {            
            Productos.Add(producto);
            Recalcular();            
        }
        public void QuitarProducto(int id_producto, int? cantidad)
        {
            if (cantidad.HasValue)
            {
                Productos = Productos.Select(producto =>
                {
                    if (producto.Producto.id == id_producto)
                    {
                        producto.cantidad -= cantidad.Value;
                        
                    }
                    return producto;
                }).ToList();
            }
            else
            {
                Productos.Remove(Productos.Where(producto => producto.Id == id_producto).FirstOrDefault());
            }
            Recalcular();            
        }
        private void Recalcular()
        {
            Productos = Productos.Select(x =>
            {
                x.subtotal = x.Producto.precio * x.cantidad;
                return x;
            }).ToList();
            Subtotal = Productos.Sum(x => x.subtotal);
            IVA = Subtotal * 0.16m;
            Total = Subtotal + IVA;
        }

    }
}
