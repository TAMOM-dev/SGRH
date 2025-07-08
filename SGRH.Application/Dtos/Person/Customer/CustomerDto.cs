
using SGRH.Domain.Entities.Configuration;

namespace SGRH.Application.Dtos.Person.Customer
{
    public record CustomerDto : BaseDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
