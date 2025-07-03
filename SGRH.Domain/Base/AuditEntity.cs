using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGRH.Domain.Base
{
    public abstract class AuditEntity 
    {
        protected AuditEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.Deleted = false;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool? Deleted { get; set; }

    }
}
