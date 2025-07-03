

namespace SGRH.Application.Dtos.Person.Customer
{
    public record CreateCustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
