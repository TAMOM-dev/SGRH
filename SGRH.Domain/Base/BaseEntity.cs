
namespace SGRH.Domain.Base
{
    public abstract class BaseEntity<Ttype> : AuditEntity
    {
        public abstract Ttype Id { set;  get; }
    }
}
