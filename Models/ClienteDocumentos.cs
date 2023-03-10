using Microsoft.EntityFrameworkCore;

namespace CSHARP_TEST1.Models
{
    // [Keyless]
    public class ClienteDocumentos
    {
        public int CodCliente { get; set; }
        public int CodDoc { get; set; }
		// public Cliente Cliente { get; set; }
	}
}
