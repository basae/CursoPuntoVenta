using CursoPuntoVenta.Models;
using CursoPuntoVenta.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CursoPuntoVenta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Venta temp= new Venta();
            temp.id_cliente = DataRepositorio.Cliente.Id.Value;
            temp.Id_empleado = DataRepositorio.Empleados.FirstOrDefault().Id.Value;
            temp.AggregarProducto(new Venta.ListaVenta { Producto = DataRepositorio.Productos.FirstOrDefault(), cantidad = 5 });

            temp.QuitarProducto(1, 1);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
