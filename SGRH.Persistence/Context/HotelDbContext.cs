using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Persistence.Context
{
    internal class HotelDbContext
    {
        public DbSet<Servicio> Servicios { get; set; }

    }
}
