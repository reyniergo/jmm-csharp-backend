using CSHARP_TEST1.Data; 
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSHARP_TEST1.Models
{
    public class Test1
    {
        public List<TipoDocumentos> List_Documento { get; set; }
        public List<Cliente> ListaCliente { get; set; }
        public string NombreApellidoCedula { get; set; }
        public int[] BusDoc { get; set; }
        

	}
}
