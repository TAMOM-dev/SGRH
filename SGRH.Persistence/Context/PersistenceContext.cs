using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities;

namespace SGRH.Persistence.Context
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options)
            : base(options)
        {
        }

        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        
    }
}
