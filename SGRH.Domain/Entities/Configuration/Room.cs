using SGRH.Domain.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Domain.Entities.Configuration
{
    public sealed class Room : AuditEntity
    {
        public string? RoomNumber { get; set; }
        public RoomCategory? Category { get; set; }
    }
}
