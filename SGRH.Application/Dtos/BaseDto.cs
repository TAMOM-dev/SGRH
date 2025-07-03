using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Application.Dtos
{
    public record BaseDto //OJO CON RECORD O CLASS
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}
