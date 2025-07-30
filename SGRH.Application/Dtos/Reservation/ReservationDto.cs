
namespace SGRH.Application.Dtos.Person.Reservation;

public record ReservationDto : BaseDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }
    public int FloorId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalCost { get; set; }
    public string Status { get; set; } = string.Empty;
}
