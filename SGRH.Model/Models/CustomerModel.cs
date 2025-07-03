

namespace SGRH.Model.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int ReservationId { set; get; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        //CreatedAt
        //UpdatedAt
        //Delete
    }
}
