

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Model.Models;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;
using System.Linq.Expressions;

namespace SGRH.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<CustomerRepository> _logger;
        private readonly IConfiguration _configuration;

        public CustomerRepository(SGRHContext context, 
                                 ILogger<CustomerRepository> logger, 
                                 IConfiguration configuration) :base(context, logger) //OJO logger
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetCustomerByReservationId(int reservationId)
        {
            OperationResult result;

            try
            {
                _logger.LogInformation("Finding the customer in reservation's id: {ReservationId}", reservationId);

                ValidationRepository.ValidateID(reservationId, _logger);

                ValidationRepository.ValidateContext(_context, _logger);

                    var querys = await (from customer in _context.Customers
                                        join reservation in _context.Reservations on customer.ReservationId equals reservation.Id
                                        where reservation.Id == reservationId
                                        select new CustomerModel()
                                        {
                                            CustomerId = customer.Id,
                                            FirstName = customer.FirstName,
                                        }).ToListAsync();

                //if(querys == null || !querys.Any())
                //{
                //    _logger.LogError("Null entity");
                //    return OperationResult.Failure("Customers not found in the reservation");
                //}

                //_logger.LogInformation("Search ended correctly");
                //result = OperationResult.Success("Customers found successfully", querys);

                ValidationRepository.ValidateQuery(querys, _logger,"No one customer found in this reservation");
                result = OperationResult.Success("Customers found successfully", querys);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "General Error. Reservation: {ReservationId}", reservationId);
                result = OperationResult.Failure("An error ocurred finding the customers.");
            }


            return result;
        }

        public override Task<OperationResult> SaveEntityAsync(Customer entity)
        {
            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Customer entity)
        {
            return base.UpdateEntityAsync(entity);
        }

        public override Task<Customer> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

        public override Task<bool> ExistsAsync(Expression<Func<Customer, bool>> filter)
        {
            return base.ExistsAsync(filter);
        }

        public override Task<List<Customer>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override Task<OperationResult> GetAllAsync(Expression<Func<Customer, bool>> filter)
        {
            return base.GetAllAsync(filter);
        }
    }
}
