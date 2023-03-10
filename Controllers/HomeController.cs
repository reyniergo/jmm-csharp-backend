using CSHARP_TEST1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CSHARP_TEST1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace CSHARP_TEST1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CSHARP_TEST1Context _TEST1Context;

        public HomeController(ILogger<HomeController> logger, CSHARP_TEST1Context TEST1Context)
        {
            _logger = logger;
            _TEST1Context = TEST1Context;
        }

        // Prueba #1
        public IActionResult Test1()
        { 
            Test1 test1 = new Test1();

            test1.List_Documento = _TEST1Context.TipoDocumentos.ToList();
			
            return View(test1);
        }

        public IActionResult ModalNuevo()
        {
			ClienteNewEdictcs cliente = new ClienteNewEdictcs();

			cliente.ListPais = _TEST1Context.Pais.ToList()
							   .Select(x => new SelectListItem { Text = x.Nacionalidad, Value = x.CodNacionalidad.ToString() })
							   .ToList();

            cliente.ListaTipoDocumentos = _TEST1Context.TipoDocumentos.ToList();


			return PartialView(cliente);
        }

        [HttpPost]
		public IActionResult ClienteNuevoEditar(ClienteNewEdictcs model)
		{

            Cliente cliente = new Cliente();
            cliente.CodNacionalidad = model.CodPais;
            cliente.Nombre = model.Nombre;
            cliente.Apellido = model.Apellido;
            cliente.Cedula = model.Cedula;
            cliente.Direccion = model.Direccion;
            cliente.Inactivo = model.Inactivo;

            _TEST1Context.Cliente.Add(cliente);
            _TEST1Context.SaveChanges();

            List<ClienteDocumentos> ListaclienteDocumentos = new List<ClienteDocumentos>();

            foreach (var item in model.CodDocumento)
            {
				ClienteDocumentos clienteDocumentos = new ClienteDocumentos();
                clienteDocumentos.CodCliente = cliente.CodCliente;
                clienteDocumentos.CodDoc = item;
                ListaclienteDocumentos.Add(clienteDocumentos);
			}

			_TEST1Context.ClienteDocumentos.AddRange(ListaclienteDocumentos); 
            _TEST1Context.SaveChanges();

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

			return Json(new { Result = true }, options);
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