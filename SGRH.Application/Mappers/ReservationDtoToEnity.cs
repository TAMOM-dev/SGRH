
using SGRH.Application.Dtos.Person.Reservation;
using SGRH.Domain.Entities.Configuration;

namespace SGRH.Application.Mappers;

public static class ReservationMapper
{
    public static ReservationDto ReservationToDto(this Reservation entity)
    {
        return new ReservationDto()
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            RoomId = entity.RoomId,
            CheckInDate = entity.CheckInDate,
            CheckOutDate = entity.CheckOutDate,
            NumberOfGuests = entity.NumberOfGuests,
            TotalCost = entity.TotalCost,
            Status = entity.Status.ToString()
        };
    }

    public static List<ReservationDto> ReservationToDtos(this List<Reservation> entities) => entities.Select(ReservationToDto).ToList();

    public static Reservation SaveReservationDtoToEntity(this SaveReservationDto dto)
    {
        return new Reservation()
        {
            CustomerId = dto.CustomerId,
            RoomId = dto.RoomId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            NumberOfGuests = dto.NumberOfGuests,
            TotalCost = dto.TotalCost,
            Status = Reservation.ReservationStatus.Pending
        };
    }

    public static Reservation UpdateReservationDtoToEntity(this UpdateReservationDto dto)
    {
        return new Reservation()
        {
            Id = dto.Id,
            CustomerId = dto.CustomerId,
            RoomId = dto.RoomId,
            CheckInDate = dto.CheckInDate,
            CheckOutDate = dto.CheckOutDate,
            NumberOfGuests = dto.NumberOfGuests,
            TotalCost = dto.TotalCost,
            Status = Reservation.ReservationStatus.Pending
        };
    }

    public static int RemoveReservationDtoToEntity(this RemoveReservationDto dto) => dto.Id;
    
}
