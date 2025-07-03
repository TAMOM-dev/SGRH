using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Configuration;


namespace SGRH.Persistence.Context
{
    public class SGRHContext : DbContext
    {
        public SGRHContext(DbContextOptions<SGRHContext> options) : base(options) { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<Floor> Floor { get; set; }
    }
}
