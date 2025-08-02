
// using Microsoft.Extensions.Logging;
// using SGRH.Application.Dtos.Person.Reservation;
// using SGRH.Application.Interfaces;
// using SGRH.Application.Mappers;
// using SGRH.Domain.Base;
// using SGRH.Domain.Entities.Configuration;
// using SGRH.Persistence.Base;
// using SGRH.Persistence.Interfaces;

// namespace SGRH.Application.Services;

// public sealed class ReservationService : IReservationService
// {
//     public readonly IReservationRepository _reservationRepository;
//     private readonly ILogger<ReservationService> _logger;

//     public ReservationService(IReservationRepository reservationRepository, ILogger<ReservationService> logger)
//     {
//         _reservationRepository = reservationRepository;
//         _logger = logger;
//     }

//     public async Task<OperationResult> GetAll()
//     {

//         try
//         {
//             var result = await _reservationRepository.GetAllAsync();
//             var data = result.Data as List<Reservation>;
//             var dtos = ReservationMapper.ReservationToDtos(data);

//             return OperationResult.Success("Reservations found successfully", dtos);
//         }
//         catch (Exception e)
//         {
//             return OperationResult.Failure("An error ocurred finding the reservations: " + e.Message);
//         }

//     }

//     public async Task<OperationResult> GetById(int Id)
//     {
//         try
//         {
//             var result = await _reservationRepository.GetEntityByIdAsync(Id);
//             var data = result.Data as Reservation;
//             var dto = ReservationMapper.ReservationToDto(data);

//             return OperationResult.Success("Reservation found successfully", dto);
//         }
//         catch (Exception e)
//         {
//             return OperationResult.Failure("An error ocurred finding the reservation: " + e.Message);
//         }
//     }

//     public async Task<OperationResult> GetReservationsByCustomerId(int customerId)
//     {
//         try
//         {
//             var data = await _reservationRepository.GetReservationsByCustomerId(customerId);
//             var reservations = data.Data as List<Reservation>;
//             ValidationRepository.ValidateEntity(reservations, _logger, "There are no reservations for this customer");

//             var dtos = ReservationMapper.ReservationToDtos(reservations);

//             return OperationResult.Success("Reservations found successfully", dtos);
//         }
//         catch (Exception e)
//         {
//             return OperationResult.Failure("An error ocurred finding the reservations: " + e.Message);
//         }

//     }


//     public async Task<OperationResult> Remove(int id)
//     {
//         try
//         {
//             var entity = await _reservationRepository.GetEntityByIdAsync(id);

//             return OperationResult.Success("Reservation deleted successfully");
//         }
//         catch (Exception e)
//         {
//             return OperationResult.Failure("An error ocurred deleting the reservation: " + e.Message);
//         }
//     }

//     public async Task<OperationResult> Save(SaveReservationDto dto)
//     {
//         try
//         {
//             if (dto.CheckInDate < DateTime.Today || dto.CheckOutDate < DateTime.Today)
//             {
//                 return OperationResult.Failure("Check in and check out dates cannot be in the past");
//             }

//             if (dto.CheckOutDate <= dto.CheckInDate)
//             {
//                 return OperationResult.Failure("Check out date cannot be before check in date");
//             }

            

//             var data = await _reservationRepository.SaveEntityAsync(dto.SaveReservationDtoToEntity());
//             return OperationResult.Success("Reservation saved successfully", data);
//         }
//         catch (Exception e)
//         {
//             return OperationResult.Failure("An error ocurred saving the reservation: " + e.Message);
//         }
//     }

//     public async Task<OperationResult> Update(UpdateReservationDto dto)
//     {
//         try
//         {
//             var data = await _reservationRepository.UpdateEntityAsync(dto.UpdateReservationDtoToEntity());
//             return OperationResult.Success("Reservation updated successfully", data);
//         }
//         catch (Exception e)
//         {
//             return OperationResult.Failure("An error ocurred updating the reservation: " + e.Message);
//         }
//     }
// }
