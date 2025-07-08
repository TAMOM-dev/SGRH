using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("RoomCategories")]
    public sealed class RoomCategory : Base.BaseEntity<int>
    {
        [Key]
        [Column("CategoryId")]
        public override int Id { set; get; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NightlyRate { get; set; }
        [Required]
        [Range(0.01, 20)]
        public int MaxGuests { get; set; }

        public bool HasBreakfast { get; set; }
        public bool HasWifi { get; set; }
        public bool HasParking { get; set; }
        public bool HasPoolAccess { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}
