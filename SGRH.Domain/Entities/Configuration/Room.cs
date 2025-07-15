
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("Rooms")]
    public sealed class Room : Base.BaseEntity<int>
    {
        [Key]
        [Column("RoomId")]
        public override int Id { set; get; }
        public string? RoomNumber { get; set; }

        [ForeignKey("Floor")]
        public int FloorId { get; set; }
        public Floor? Floor { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public RoomCategory? Category { get; set; }


        public int MaxCapacity { get; set; }
        public bool IsAvailable { get; set; }

    }
}
