
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGRH.Domain.Entities.Configuration
{
    [Table("Floors")]
    public sealed class Floor : Base.BaseEntity<int>
    {
        [Key]
        [Column("FloorId")]
        public override int Id { set; get; }
        public int FloorNumber { set; get; }
        public ICollection<Room>? Rooms { set; get; }
    }
}
