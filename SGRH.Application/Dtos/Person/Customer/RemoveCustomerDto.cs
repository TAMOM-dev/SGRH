

namespace SGRH.Application.Dtos.Person.Customer
{
    public record RemoveCustomerDto : BaseDto
    {
        public int Id { get; set; }
        public bool Removed { get; set; }
    }
}
