using System;
using SGRH.Application.Dtos.RoomCategory;

namespace SGRH.Application.Base.Validators.RoomCategory;

public class SaveCategoryRoomDtoValidator : BaseValidator<SaveRoomCategoryDto>
{
    public SaveCategoryRoomDtoValidator()
    {
        ValidateString(x => x.Name, "Name", 100);
        ValidatePositiveNumber(x => x.NightlyRate, "Nightly Rate");
    }
}
