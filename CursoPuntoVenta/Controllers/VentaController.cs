using CursoPuntoVenta.Models;
using CursoPuntoVenta.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CursoPuntoVenta.Models.Venta;

namespace CursoPuntoVenta.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Empleados"] = DataRepositorio.Empleados.Select(x => new SelectListItem { Text = string.Join(" ", x.Nombre, x.Apellidos), Value = x.Id.ToString() });
            ViewData["Cliente_Nombre"] = DataRepositorio.Cliente.Nombre;
            ViewData["Cliente_Id"] = DataRepositorio.Cliente.Id;
            ViewData["Productos"] = DataRepositorio.Productos;

            return View();
        }
        [HttpPost]
        public IActionResult Index(Venta _venta)
        {
            return View(_venta);
        }

        [HttpPost]
        public IActionResult AgregaProducto([FromBody]Venta _venta,[FromQuery]int id_producto, [FromQuery] int cantidad, int cantidadAntesCambio)
        {            
            try
            {
                if (cantidadAntesCambio > 0)
                    _venta.QuitarProducto(id_producto, cantidadAntesCambio);

                _venta.AggregarProducto(new ListaVenta { Producto=new Producto { id = id_producto },cantidad=cantidad });
                return Json(new { Result = _venta, Error = false, Message = "" });
            }
            catch(Exception ex)
            {
                return Json(new { Result= _venta, Error = true, Message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult QuitarProducto([FromBody] Venta _venta, [FromQuery] int id_producto)
        {
            try
            {                
                _venta.QuitarProducto(id_producto);
                return Json(new { Result = _venta, Error = false, Message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = _venta, Error = true, Message = ex.Message });
            }
        }
    }
}
