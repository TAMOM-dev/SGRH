
namespace SGRH.Application.Dtos.Person.Customer
{
    public record ModifyCustomerDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? UpdatedDate { get; set;} = DateTime.UtcNow;
    }
}
