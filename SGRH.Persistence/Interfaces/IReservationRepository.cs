using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Repository;


namespace SGRH.Persistence.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<OperationResult> GetReservationsByCustomerId(int customerId);
        Task<OperationResult> GetReservationsByFloorAsync(int floorId);
        Task<bool> HasReservationConflictAsync(
            int roomId,
            DateTime chaeckInDate,
            DateTime checkOutDate,
            int? excludeReservationId = null
            );
    }
}
