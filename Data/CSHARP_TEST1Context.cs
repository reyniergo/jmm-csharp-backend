using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSHARP_TEST1.Models;

namespace CSHARP_TEST1.Data
{
    public class CSHARP_TEST1Context : DbContext
    {
        public CSHARP_TEST1Context (DbContextOptions<CSHARP_TEST1Context> options)
            : base(options)
        {
        }

        public DbSet<CSHARP_TEST1.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<CSHARP_TEST1.Models.TipoDocumentos> TipoDocumentos { get; set; }

        public DbSet<CSHARP_TEST1.Models.Pais> Pais { get; set; }
    }
}
