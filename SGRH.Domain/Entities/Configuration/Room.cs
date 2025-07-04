﻿using SGRH.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Domain.Entities.Configuration
{
    [Table("Rooms")]
    public sealed class Room : Base.BaseEntity<int>
    {
        [Key]
        [Column("RoomId")]
        public override int Id { set; get; }
        public string? RoomNumber { get; set; }
        public RoomCategory? Category { get; set; }

    }
}
