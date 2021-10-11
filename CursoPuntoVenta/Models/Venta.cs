using CursoPuntoVenta.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Models
{
    public class Venta
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="El campo empleado debe estar lleno")]
        public int? Id_empleado { get; set; }
        [Display(Name ="Fecha de Venta XD")]
        public DateTime FechaVenta { get; set; }
        [Display(Name ="SubTotal")]
        public decimal Subtotal { get; set; }
        [Display(Name = "Descuento")]
        public decimal Descuento { get; set; }
        [Display(Name = "IVA")]
        public decimal IVA { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage ="El campo cliente debe tener algún valor")]
        public int? id_cliente { get; set; }
        [Display(Name = "Puntos")]        
        public int? PuntosGenerados { get; set; }
        public List<ListaVenta> Productos { get; set; }
        public Venta()
        {
            Productos = new List<ListaVenta>();
        }
        public class ListaVenta
        {
            public int? Id { get; set; }
            public Producto Producto { get; set; }
            public decimal cantidad { get; set; }
            public decimal subtotal { get; set; }
        }
        public void AggregarProducto(ListaVenta producto)
        {
            if (DataRepositorio.BuscaProducto(producto.Producto.id.Value).Existencia >= producto.cantidad)
            {
                Productos.Add(producto);
                DataRepositorio.MoverExistencia(producto.Producto.id.Value, producto.cantidad);
                Recalcular();         
            }
            else
            {
                throw new Exception("no hay existencia del producto.");
            }
        }
        public void QuitarProducto(int id_producto, int? cantidad = null)
        {
            Producto producto = DataRepositorio.BuscaProducto(id_producto);
            decimal _cantidad=0;
            if (producto != null)
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
                    _cantidad = cantidad.Value;
                }
                else
                {
                    _cantidad = Productos.Where(producto => producto.Producto.id == id_producto).FirstOrDefault().cantidad;
                    int? _productoBuscado = Productos.Select((objecto, pos) => new { pos, objecto }).Where(x => x.objecto.Producto.id == id_producto).Select(x => x.pos).FirstOrDefault();
                    Productos.RemoveAt(_productoBuscado.Value);
                }
                DataRepositorio.MoverExistencia(producto.id.Value, -1 * _cantidad);
                Recalcular();
            }
        }
        private void Recalcular()
        {
            Productos = Productos.Select(x =>
            {
                x.subtotal = x.Producto.Precio * x.cantidad;
                return x;
            }).ToList();
            Subtotal = Productos.Sum(x => x.subtotal);
            IVA = Subtotal * 0.16m;
            Total = Subtotal + IVA;
        }
        public void TerminarVenta()
        {

        }
    }
}
