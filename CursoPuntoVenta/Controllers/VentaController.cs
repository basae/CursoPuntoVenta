using CursoPuntoVenta.Models;
using CursoPuntoVenta.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Empleados"] = DataRepositorio.Empleados.Select(x=> new SelectListItem { Text= string.Join(" ", x.Nombre,x.Apellidos), Value= x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public IActionResult Index(Venta _venta)
        {
            return View(_venta);
        }
    }
}
