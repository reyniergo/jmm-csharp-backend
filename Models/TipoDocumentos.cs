using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSHARP_TEST1.Models
{
    public class TipoDocumentos
    {
        [Key]
        public int CodDoc { get; set; }
        public string Titulo { get; set; }
        public string Inactivo { get; set; }
    }
}
