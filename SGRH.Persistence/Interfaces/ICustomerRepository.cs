using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Persistence.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<OperationResult> GetCustomerByReservationId(int reservationID);

    }
}
