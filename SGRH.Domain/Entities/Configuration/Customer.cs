using SGRH.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("Customers")]
    public sealed class Customer : Person<int>
    {
        [Key]
        [Column("Id")]
        public override int Id { set; get; } 
        public string? Address { get; set; }
        public int ReservationId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
