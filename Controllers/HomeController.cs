using CSHARP_TEST1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CSHARP_TEST1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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

        public IActionResult TablaCliente(Test1 model) 
        {

			Test1 test1 = new Test1();
			test1.ListaCliente = _TEST1Context.Cliente.ToList();

            if(model.NombreApellidoCedula != null || model.BusDoc != null)
            {
                if (model.NombreApellidoCedula != null && model.NombreApellidoCedula.Length > 0)
                {
                    test1.ListaCliente = test1.ListaCliente.Where(x => x.Nombre == model.NombreApellidoCedula || x.Apellido == model.NombreApellidoCedula || x.Cedula == model.NombreApellidoCedula).ToList();
                }

                if (model.BusDoc != null && model.BusDoc.Length > 0)
                {
                    var documento = _TEST1Context.ClienteDocumentos.ToList();

                    List<Cliente> clientes = new List<Cliente>();
                    List<ClienteDocumentos> clienteDocumento = new List<ClienteDocumentos>();

                    foreach (var item in model.BusDoc)
                    {
						clienteDocumento.AddRange(documento.Where(x => x.CodDoc == item).ToList());

					}

                    foreach (var item in clienteDocumento)
                    {
						clientes.AddRange(test1.ListaCliente.Where(x => x.CodCliente == item.CodCliente).ToList());

					}

                    test1.ListaCliente = clientes;

				}
			}

			return PartialView(test1);
        }

        public IActionResult ModalNuevo(int ClienteCod = 0)
        {
			ClienteNewEdictcs cliente = new ClienteNewEdictcs();
            cliente.ClienteCod = ClienteCod;

			cliente.ListPais = _TEST1Context.Pais.ToList()
							   .Select(x => new SelectListItem { Text = x.Nacionalidad, Value = x.CodNacionalidad.ToString() })
							   .ToList();

            cliente.ListaTipoDocumentos = _TEST1Context.TipoDocumentos.ToList();

            if(ClienteCod > 0)
            {
               var clienteDb = _TEST1Context.Cliente.FirstOrDefault(x => x.CodCliente == ClienteCod);

                cliente.CodPais = clienteDb.CodNacionalidad;
                cliente.Nombre = clienteDb.Nombre;
                cliente.Apellido = clienteDb.Apellido;
                cliente.Cedula = clienteDb.Cedula;
                cliente.Inactivo = clienteDb.Inactivo;
                cliente.Direccion = clienteDb.Direccion;
                cliente.CodDocumento = _TEST1Context.ClienteDocumentos.Where(x => x.CodCliente == ClienteCod).Select(x => x.CodDoc).ToArray();

			}


			return PartialView(cliente);
        }

        [HttpPost]
		public IActionResult ClienteNuevoEditar(ClienteNewEdictcs model)
		{
            Cliente cliente = new Cliente();


			if (model.ClienteCod > 0)
            {
                var ClienteUpdate  = _TEST1Context.Cliente.FirstOrDefault(x => x.CodCliente == model.ClienteCod);
				ClienteUpdate.CodNacionalidad = model.CodPais;
				ClienteUpdate.Nombre = model.Nombre;
				ClienteUpdate.Apellido = model.Apellido;
				ClienteUpdate.Cedula = model.Cedula;
				ClienteUpdate.Direccion = model.Direccion;
				ClienteUpdate.Inactivo = model.Inactivo;
                cliente.CodCliente = ClienteUpdate.CodCliente;

			}
            else
			{
				
				cliente.CodNacionalidad = model.CodPais;
				cliente.Nombre = model.Nombre;
				cliente.Apellido = model.Apellido;
				cliente.Cedula = model.Cedula;
				cliente.Direccion = model.Direccion;
				cliente.Inactivo = model.Inactivo;
				_TEST1Context.Cliente.Add(cliente);
			}

            _TEST1Context.SaveChanges();


            // Se elimina los documento del client
            var documentos = _TEST1Context.ClienteDocumentos.Where(x => x.CodCliente == cliente.CodCliente);

            if(documentos != null)
            {
                _TEST1Context.RemoveRange(documentos);
                _TEST1Context.SaveChanges();

			}

            List<ClienteDocumentos> ListaclienteDocumentos = new List<ClienteDocumentos>();

            if (model.CodDocumento != null ) { 
                foreach (var item in model.CodDocumento)
                {
				    ClienteDocumentos clienteDocumentos = new ClienteDocumentos();
                    clienteDocumentos.CodCliente = cliente.CodCliente;
                    clienteDocumentos.CodDoc = item;
                    ListaclienteDocumentos.Add(clienteDocumentos);
			    }

			    _TEST1Context.ClienteDocumentos.AddRange(ListaclienteDocumentos); 
                _TEST1Context.SaveChanges();
			}

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