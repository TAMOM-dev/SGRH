using SGRH.Application.Dtos.RoomCategory;
using SGRH.Domain.Entities.Configuration;

namespace SGRH.Application.Mappers;

public static class RoomCategoryMapper
{
    public static RoomCategory SaveRoomCategoryDtoToEntity(this SaveRoomCategoryDto dto)
    {
        return new RoomCategory()
        {
            Name = dto.Name,
            Description = dto.Description,
            NightlyRate = dto.NightlyRate,
            MaxGuests = dto.MaxGuests,
            HasBreakfast = dto.HasBreakfast,
            HasWifi = dto.HasWifi,
            HasParking = dto.HasParking,
            HasPoolAccess = dto.HasPoolAccess,
            CreatedAt = DateTime.Now,
        };
    }

    public static RoomCategory UpdateRoomCategoryDtoToEntity(this UpdateRoomCategoryDto dto)
    {
        return new RoomCategory()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            NightlyRate = dto.NightlyRate,
            MaxGuests = dto.MaxGuests,
            HasBreakfast = dto.HasBreakfast,
            HasWifi = dto.HasWifi,
            HasParking = dto.HasParking,
            HasPoolAccess = dto.HasPoolAccess,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    public static RoomCategoryDto RoomCategoryToDto(this RoomCategory entity)
    {
        return new RoomCategoryDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            NightlyRate = entity.NightlyRate,
            MaxGuests = entity.MaxGuests,
            HasBreakfast = entity.HasBreakfast,
            HasWifi = entity.HasWifi,
            HasParking = entity.HasParking,
            HasPoolAccess = entity.HasPoolAccess,
            ChangeDate = entity.UpdatedAt,
        };
    }

    public static List<RoomCategoryDto> RoomCategoriesToDto(this List<RoomCategory> entities)
    {
        return entities.Select(entity => entity.RoomCategoryToDto()).ToList();
    }

    public static int RemoveRoomCategoryDtoToEntity(this RemoveRoomCategoryDto dto) => dto.Id;
}
