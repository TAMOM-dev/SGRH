using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SGRH.Application.Base.Validators.RoomCategory;
using SGRH.Application.Dtos.RoomCategory;
using SGRH.Application.Interfaces;
using SGRH.Application.Services.RoomCategories;
using SGRH.Persistence.Base;
using SGRH.Persistence.Base.Intefaces;
using SGRH.Persistence.Interfaces;
using SGRH.Persistence.Repositories;

namespace SGRH.IOC.Dependencies
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection service)
        {
            service.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
            service.AddTransient<IRoomCategoryService, RoomCategoryService>();
            service.AddScoped<IValidationRepository, ValidationRepository>();

            // FluentValidation
            service.AddScoped<IValidator<SaveRoomCategoryDto>, SaveCategoryRoomDtoValidator>();
            service.AddScoped<IValidator<UpdateRoomCategoryDto>, UpdateRoomCategoryDtoValidator>();

        }
    }
}
