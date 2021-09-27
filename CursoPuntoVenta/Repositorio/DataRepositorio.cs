using CursoPuntoVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Repositorio
{
    public static class DataRepositorio
    {
        public static Sucursal GetSucursal()
        {
            return new Sucursal { Id = 1, Nombre = "CHACAL CITY", Direccion = "Barrio de tepito S/N" };
        }
        public static List<Empleados> getEmpleados()
        {
            return
                new List<Empleados> {
                    new Empleados { Id=1, Nombre="winnieberto", Direccion="rio missisipi 160", Apellidos="bastar", Edad=100, Sexo='H', Sucursal=GetSucursal() },
                    new Empleados { Id=2, Nombre="wichona", Direccion="andandor S/N", Apellidos="alvarez", Edad=100, Sexo='G', Sucursal=GetSucursal() }
                };
        }
        public static List<Proveedor> GetProveedores()
        {
            return new List<Proveedor>
            {
                new Proveedor{ Id=1,Nombre="SABRITAS", RFC="SAB123456" },
                new Proveedor{ Id=2,Nombre="COCA", RFC="COC12345" },
                new Proveedor{ Id=3,Nombre="BACHOCO", RFC="123SADASDF" }
            };
        }
        public static List<Producto> GetProductos()
        {
            return new List<Producto>
            {
                new Producto{ id=1, Nombre="PAPITAS ADOBADAS", Existencia=10, id_proveedor=1, id_Sucursal= 1, precio=15.50M, Unidad="PZA" },
                new Producto{ id=2, Nombre="COCACOLA 600ML", Existencia=10, id_proveedor=2, id_Sucursal= 1, precio=16, Unidad="PZA" },
                new Producto{ id=3, Nombre="PECHUGA DE POLLO", Existencia=10, id_proveedor=3, id_Sucursal= 1, precio=40, Unidad="KG" }
            };
        }
        public static List<Cliente> GetClientes()
        {
            return new List<Cliente>
            {
                new Cliente{ Id=1,Nombre="jorge",Apellidos="chilorio", Direccion="john spark 150", Edad=34, Puntos=0, Sexo='H'  }
            };  
        }
    }
}
