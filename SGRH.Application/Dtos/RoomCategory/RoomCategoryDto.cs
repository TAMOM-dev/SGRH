
using SGRH.Application.Dtos.Room;

namespace SGRH.Application.Dtos.RoomCategory;

public record class RoomCategoryDto : BaseDto
{
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal NightlyRate { get; set; }
        public int MaxGuests { get; set; }
        public bool HasBreakfast { get; set; }
        public bool HasWifi { get; set; }
        public bool HasParking { get; set; }
        public bool HasPoolAccess { get; set; }
        public int RoomCount { get; set; }
}
