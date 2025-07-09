
using Microsoft.Extensions.Logging;
using SGRH.Application.Dtos.Person.Reservation;
using SGRH.Application.Interfaces;
using SGRH.Application.Mappers;
using SGRH.Domain.Base;
using SGRH.Persistence.Base;
using SGRH.Persistence.Interfaces;

namespace SGRH.Application.Services;

public sealed class ReservationService : IReservationService
{
    public readonly IReservationRepository _reservationRepository;
    private readonly ILogger<ReservationService> _logger;

    public ReservationService(IReservationRepository reservationRepository, ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _logger = logger;
    }

    public async Task<OperationResult> GetAll()
    {

        try
        {
            var data = await _reservationRepository.GetAllAsync();
            return OperationResult.Success("Reservations found successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error retrieving all reservations: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the reservations");
        }

    }

    public async Task<OperationResult> GetById(int Id)
    {
        try
        {
            var data = await _reservationRepository.GetEntityByIdAsync(Id);
            return OperationResult.Success("Reservation found successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error retrieving reservation {Id}: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the reservation");
        }
    }

    public async Task<OperationResult> GetReservationsByCustomerId(int customerId)
    {
        try
        {
            var data = await _reservationRepository.GetReservationsByCustomerId(customerId);
            return OperationResult.Success("Reservations found successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error retrieving reservations by customer id {customerId}: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the reservations");
        }

    }

    public async Task<OperationResult> GetReservationsByFloorAsync(int floorId)
    {
        try
        {
            var data = await _reservationRepository.GetReservationsByFloorAsync(floorId);
            return OperationResult.Success("Reservations found successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error retrieving reservations by floor id {floorId}: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the reservations");
        }
    }

    public async Task<OperationResult> Remove(RemoveReservationDto dto)
    {
        try
        {
            var entity = await _reservationRepository.GetEntityByIdAsync(dto.Id);
            ValidationRepository.ValidateEntity(entity, _logger, "Reservation doesn't exist");

            var data = await _reservationRepository.DeleteEntityAsync(entity);
            return OperationResult.Success("Reservation deleted successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error deleting reservation {dto.Id}: {e.Message}");
            return OperationResult.Failure("An error ocurred deleting the reservation");
        }
    }

    public async Task<OperationResult> Save(SaveReservationDto dto)
    {
        try
        {
            if (dto.CheckInDate < DateTime.Today || dto.CheckOutDate < DateTime.Today)
            {
                return OperationResult.Failure("Check in and check out dates cannot be in the past");
            }

            if (dto.CheckOutDate <= dto.CheckInDate)
            {
                return OperationResult.Failure("Check out date cannot be before check in date");
            }

            var data = await _reservationRepository.SaveEntityAsync(dto.SaveReservationDtoToEntity());
            return OperationResult.Success("Reservation saved successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error saving reservation: {e.Message}");
            return OperationResult.Failure("An error ocurred saving the reservation");
        }
    }

    public async Task<OperationResult> Update(UpdateReservationDto dto)
    {
        try
        {
            var data = await _reservationRepository.UpdateEntityAsync(dto.UpdateReservationDtoToEntity());
            return OperationResult.Success("Reservation updated successfully", data);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error updating reservation: {e.Message}");
            return OperationResult.Failure("An error ocurred updating the reservation");
        }
    }
}
