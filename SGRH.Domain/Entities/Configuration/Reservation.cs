using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("Reservations")]
    public sealed class Reservation : Base.BaseEntity<int>
    {
        
        [Key]
        [Column("ReservationId")]
        public override int Id { set; get; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalCost { get; set; }
    }
}
