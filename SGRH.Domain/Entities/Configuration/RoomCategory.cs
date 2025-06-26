using SGRH.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Domain.Entities.Configuration
{
    public sealed class RoomCategory : AuditEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal NightlyRate { get; set; }
        public int MaxGuests { get; set; }
    }
}
