using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Domain.Entities.Configuration
{
    [Table("Floors")]
    public sealed class Floor : Base.BaseEntity<int>
    {
        [Key]
        [Column("FloorId")]
        public override int Id { set; get; }
        public int FloorNumber { set; get; }
        public int RoomId { set; get; }
        public List<Room>? Rooms { set; get; }
    }
}
