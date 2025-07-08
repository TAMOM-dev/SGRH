namespace SGRH.Application.Dtos.Person.Reservation;

public record class RemoveReservationDto : BaseDto
{
    public int Id { get; set; }
    public bool Removed { get; set; }
}
