using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSHARP_TEST1.Models
{
	public class ClienteNewEdictcs
	{
		public List<SelectListItem> ListPais { get; set; }	
		public List<TipoDocumentos> ListaTipoDocumentos { get; set; }
		public bool Inactivo { get; set; }
		public int CodPais { get; set; }
		public int[] CodDocumento { get; set; }
		public string Cedula { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
	}
}
