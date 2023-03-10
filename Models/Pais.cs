using System.ComponentModel.DataAnnotations;

namespace CSHARP_TEST1.Models
{
    public class Pais
    {
        [Key]
        public int CodNacionalidad { get; set; }
        public string Nacionalidad { get; set; }
    }
}
