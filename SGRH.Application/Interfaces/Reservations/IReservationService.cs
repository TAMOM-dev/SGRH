
using SGRH.Application.Base;
using SGRH.Application.Dtos.Person.Reservation;
using SGRH.Domain.Base;

namespace SGRH.Application.Interfaces
{
    public interface IReservationService : IBaseService<SaveReservationDto, UpdateReservationDto, RemoveReservationDto>
    {
        Task<OperationResult> GetReservationsByCustomerId(int customerId);
    }
}

