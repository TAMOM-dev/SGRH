using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories
{
    public sealed class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<ReservationRepository> _logger;
        // private readonly IConfiguration _configuration;

        public ReservationRepository(SGRHContext context, ILogger<ReservationRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> GetReservationsByCustomerId(int customerId)
        {
            try
            {
                ValidationRepository.ValidateID(customerId, _logger);

                var query = _context.Reservations.Where(c => c.CustomerId == customerId);

                ValidationRepository.ValidateQuery(query.ToList(), _logger, "Cannot found a reservation with the customer id.");

                var reservations = await query.ToListAsync();
                return OperationResult.Success("Reservations in customer's id found", reservations);
            }
            catch (Exception e)
            {
                ValidationRepository.LogError(_logger, "Error finding reservations: " + e.Message);
                return OperationResult.Failure("An error ocurred finding the customer's reservations");
            }
        }

        //public async Task<OperationResult> GetReservationsByFloorAsync(int floorId)
        //{
        //    try
        //    {
        //        ValidationRepository.ValidateContext(_context, _logger);
        //        ValidationRepository.ValidateID(floorId, _logger);

        //        var query = _context.Reservations.Where(r => r.FloorId == floorId);
        //        var reservations = await query.ToListAsync();

        //        ValidationRepository.ValidateQuery(reservations, _logger, "Cannot found a reservation with the floor id.");
        //        return OperationResult.Success("Floor's reservations found", query);

        //    }

        //    catch (Exception e)
        //    {
        //        ValidationRepository.LogError(_logger, "Error finding reservations: " + e.Message);
        //        return OperationResult.Failure("An error ocurred finding the floor's reservations");
        //    }
        //}

        public override Task<OperationResult> GetAllAsync()
        {
            ValidationRepository.ValidateContext(_context, _logger);
            ValidationRepository.LogInformation(_logger, "Getting all reservations");
            var reservations = base.GetAllAsync();

            ValidationRepository.ValidateEntity(reservations.Result, _logger, "Cannot found a reservation");

            return reservations;
        }

        public override Task<OperationResult> GetEntityByIdAsync(int id)
        {
            ValidationRepository.ValidateContext(_context, _logger);
            ValidationRepository.ValidateID(id, _logger);

            var reservation = base.GetEntityByIdAsync(id);
            ValidationRepository.ValidateEntity(reservation.Result, _logger, "Cannot found a reservation");

            return reservation;
        }

        public override Task<OperationResult> SaveEntityAsync(Reservation entity)
        {
            ValidationRepository.ValidateContext(_context, _logger);
            ValidationRepository.ValidateEntity(entity, _logger, "Cannot save a reservation");

            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> DeleteEntityAsync(Reservation entity)

        {
            ValidationRepository.ValidateContext(_context, _logger);
            ValidationRepository.ValidateEntity(entity, _logger, "Error deleting a reservation");

            return base.DeleteEntityAsync(entity);
        }

        public async Task<bool> HasReservationConflictAsync(
            int roomId,
            DateTime chaeckInDate,
            DateTime checkOutDate,
            int? excludeReservationId = null
            )
        {
            return await Entity.AnyAsync(r =>
                r.RoomId == roomId &&
                r.Id != excludeReservationId &&
                r.Status == Reservation.ReservationStatus.Confirmed &&
                !(r.CheckOutDate <= chaeckInDate || r.CheckInDate >= checkOutDate)
            );
        }       
    }   
}
