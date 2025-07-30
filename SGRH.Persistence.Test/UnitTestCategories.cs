// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using SGRH.Domain.Base;
// using SGRH.Domain.Entities.Configuration;
// using SGRH.Persistence.Context;
// using SGRH.Persistence.Interfaces;
// using SGRH.Persistence.Repositories;

// namespace SGRH.Persistence.Test
// {
//     public class UnitTestCategories
//     {
//         private readonly DbContextOptions<SGRHContext> _options;

//         public UnitTestCategories()
//         {
//             _options = new DbContextOptionsBuilder<SGRHContext>()
//                 .UseInMemoryDatabase(databaseName: "SGRH")
//                 .Options;

//             var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
//             var logger = loggerFactory.CreateLogger<RoomCategoryRepository>();


//             using var context = new SGRHContext(_options);
//             var repository = new RoomCategoryRepository(context, logger);
            
//         }       

//         [Fact]
//         public async Task SaveCategory_ShouldReturnFailuer_WhenHasNoName()
//         {
//             var category = new RoomCategory { Name = ""};

//             await repository
//         }
//     }
// }