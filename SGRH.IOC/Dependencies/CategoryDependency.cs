using Microsoft.Extensions.DependencyInjection;
using SGRH.Application.Interfaces;
using SGRH.Application.Services;
using SGRH.Application.Services.RoomCategories;
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
        }
    }
}
