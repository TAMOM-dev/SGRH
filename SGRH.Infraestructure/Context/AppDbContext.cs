using Microsoft.EntityFrameworkCore;
using SGRH.Infraestructure.Entities;
using System.Collections.Generic;

namespace SGRH.Infraestructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
