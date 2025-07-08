

namespace SGRH.Application.Dtos
{
    public record BaseDto //OJO CON RECORD O CLASS
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}
