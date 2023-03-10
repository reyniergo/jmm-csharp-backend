using CSHARP_TEST1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSHARP_TEST1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Prueba #1
        public IActionResult Test1()
        {
            return View();
        }

        // Prueba #2
        public IActionResult Test2()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // ACCIONES
        public IActionResult GetClientes() { 
        
            return View();
        }

        public IActionResult PostCliente()
        {

            return View();
        }

        public IActionResult PutCliente()
        {

            return View();
        }
    }
}