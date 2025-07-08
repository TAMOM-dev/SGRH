namespace SGRH.Application.Dtos.Person.Reservation;

public record class UpdateReservationDto : ReservationDto
{
    public int Id { get; set; }
}
