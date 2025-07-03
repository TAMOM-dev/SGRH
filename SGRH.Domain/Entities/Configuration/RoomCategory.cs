using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("RoomCategories")]
    public sealed class RoomCategory : Base.BaseEntity<int>
    {
        [Key]
        [Column("CategoryId")]
        public override int Id { set;  get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal NightlyRate { get; set; }
        public int MaxGuests { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
