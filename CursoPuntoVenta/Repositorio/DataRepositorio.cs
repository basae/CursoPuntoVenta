using CursoPuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Repositorio
{
    public static class DataRepositorio
    {
        public static List<Empleados> Empleados= new List<Empleados> {
                    new Empleados { Id=1, Nombre="winnieberto", Direccion="rio missisipi 160", Apellidos="bastar", Edad=100, Sexo='H', Sucursal=Sucursal },
                    new Empleados { Id=2, Nombre="wichona", Direccion="andandor S/N", Apellidos="alvarez", Edad=100, Sexo='G', Sucursal=Sucursal }
                };
        public static Sucursal Sucursal = new Sucursal { Id = 1, Nombre = "CHACAL CITY", Direccion = "Barrio de tepito S/N" };
        public static List<Proveedor> Proveedores = new List<Proveedor>
            {
                new Proveedor{ Id=1,Nombre="SABRITAS", RFC="SAB123456" },
                new Proveedor{ Id=2,Nombre="COCA", RFC="COC12345" },
                new Proveedor{ Id=3,Nombre="BACHOCO", RFC="123SADASDF" }
            };
        public static List<Producto> Productos = new List<Producto>
            {
                new Producto{ id=1, Nombre="PAPITAS ADOBADAS", Existencia=10, id_proveedor=1, id_Sucursal= 1, Precio=15.50M, Unidad="PZA" },
                new Producto{ id=2, Nombre="COCACOLA 600ML", Existencia=10, id_proveedor=2, id_Sucursal= 1, Precio=16, Unidad="PZA" },
                new Producto{ id=3, Nombre="PECHUGA DE POLLO", Existencia=10, id_proveedor=3, id_Sucursal= 1, Precio=40, Unidad="KG" }
            };
        public static Cliente Cliente = new Cliente { Id = 1, Nombre = "jorge", Apellidos = "chilorio", Direccion = "john spark 150", Edad = 34, Puntos = 0, Sexo = 'H' };
        public static List<Venta> Ventas = new List<Venta>();
        public static List<Empleados> BuscaEmpleados(string palabra)
        {
            return Empleados.Where(x=>x.Nombre.ToUpper().Contains(palabra.ToUpper()) || x.Apellidos.ToUpper().Contains(palabra.ToUpper())).ToList();
        }
        public static List<Proveedor> BuscaProveedores(string palabra)
        {
            return Proveedores.Where(x => x.Nombre.ToUpper().Contains(palabra.ToUpper()) || x.RFC.ToUpper().Contains(palabra.ToUpper())).ToList();
        }
        public static List<Producto> BuscaProductos(string producto)
        {
            return Productos.Where(x => x.Nombre.ToUpper().Contains(producto.ToUpper())).ToList();
        }
        public static Producto BuscaProducto(int id)
        {
            return Productos.Where(x => x.id==id).FirstOrDefault();
        }
        public static List<Producto> BuscaProductosPorProveedor(string Nombreproveedor)
        {
            return (from producto in Productos
                   join proveedor in Proveedores on producto.id_proveedor equals proveedor.Id
                   where proveedor.Nombre.ToUpper().Contains(Nombreproveedor.ToUpper())
                   select producto).ToList();
                   
        }
        public static void MoverExistencia(int id_producto,decimal cantidad)
        {
            int? _productoBuscado = Productos.Select((objecto, pos) => new { pos, objecto }).Where(x => x.objecto.id == id_producto).Select(x => x.pos).FirstOrDefault();            
            if (_productoBuscado.HasValue)
            {
                Productos[_productoBuscado.Value].Existencia -= cantidad;
            }
        }
    }
}
