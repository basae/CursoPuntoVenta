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
            ViewData["Empleados"] = DataRepositorio.Empleados.Select(x=> new SelectListItem { Text= string.Join(" ", x.Nombre,x.Apellidos), Value= x.Id.ToString() });
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
        public IActionResult AgregaProducto([FromBody] ListaVenta producto)
        {
            Venta venta = new Venta();
            try
            {
                venta.AggregarProducto(producto);
                return Json(new { Result = venta,Error = false, Message = "" });
            }
            catch(Exception ex)
            {
                return Json(new { Result= venta, Error = true, Message = ex.Message });
            }
        }
    }
}
