using Microsoft.EntityFrameworkCore;
using SGRH.Infrastructure.Entities;
using System.Collections.Generic;

namespace SGRH.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Servicio> Servicios { get; set; }
    }
}
