

using SGRH.Application.Dtos.Person.Customer;
using SGRH.Domain.Entities.Configuration;

namespace SGRH.Application.Mappers
{
    public static class CustomerToDto
    {
        public static Customer SaveCustomerDtoToEntity(this SaveCustomerDto dto)
        {
            return new Customer()
            {
                Address = dto.Address,
                FirstName = dto.Name,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };
        }
    }
}
