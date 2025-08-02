using System;
using SGRH.Application.Dtos.RoomCategory;

namespace SGRH.Application.Base.Validators.RoomCategory;

public class UpdateRoomCategoryDtoValidator : BaseValidator<UpdateRoomCategoryDto>
{
    public UpdateRoomCategoryDtoValidator()
    {
        ValidateId(x => x.Id);
        ValidateString(x => x.Name, "Name", 100);
        ValidatePositiveNumber(x => x.NightlyRate, "Nightly Rate");
    }
}
