using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("Reservations")]
    public sealed class Reservation : Base.BaseEntity<int>
    {
        
        public enum ReservationStatus
        {
            Confirmed,
            Cancelled,
            Pending
        }
        
        [Key]
        [Column("ReservationId")]
        public override int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int FloorId { get; set; }
        public Floor? Floor { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalCost { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}
