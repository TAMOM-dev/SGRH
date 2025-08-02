using FluentValidation;
using Microsoft.Extensions.Logging;
using SGRH.Application.Dtos.RoomCategory;
using SGRH.Application.Interfaces;
using SGRH.Application.Mappers;
using SGRH.Domain.Base;
using SGRH.Domain.Entities.Configuration;
using SGRH.Persistence.Base;
using SGRH.Persistence.Interfaces;

namespace SGRH.Application.Services.RoomCategories;

public sealed class RoomCategoryService : IRoomCategoryService
{

    public readonly IRoomCategoryRepository _categoryRepository;
    private readonly ILogger<RoomCategoryService> _logger;
    private readonly IValidator<SaveRoomCategoryDto> _saveValidator;
    private readonly IValidator<UpdateRoomCategoryDto> _updateValidator;
    public RoomCategoryService(
        IRoomCategoryRepository roomCategoryRepository,
        ILogger<RoomCategoryService> logger,
        IValidator<SaveRoomCategoryDto> saveValidator,
        IValidator<UpdateRoomCategoryDto> updateValidator)
    {
        _categoryRepository = roomCategoryRepository;
        _logger = logger;
        _saveValidator = saveValidator;
        _updateValidator = updateValidator;
    }
    public async Task<OperationResult> GetAll()
    {  
        var repoResult = await _categoryRepository.GetAllAsync();
        if(!repoResult.isSuccess)
            return OperationResult.Failure("An error ocurred retrieving room categories");

        var dtos = RoomCategoryMapper.RoomCategoriesToDto(repoResult.Data);
        return OperationResult.Success("Room categories found successfully", dtos); 
    }

    public async Task<OperationResult> GetById(int id)
    {       
            var repoResult = await _categoryRepository.GetEntityByIdAsync(id);
            if(!repoResult.isSuccess)
                return OperationResult.Failure("Room category not found");

            var dto = RoomCategoryMapper.RoomCategoryToDto(repoResult.Data);
            return OperationResult.Success("Room category found successfully", dto);
    }

    public async Task<OperationResult> Remove(int id)
    {
        var repoResult = await _categoryRepository.GetEntityByIdAsync(id);
        if(!repoResult.isSuccess)
            return repoResult;

        var category = repoResult.Data as RoomCategory;
        if(category == null)
            return OperationResult.Failure("Room category not found");
        
        try
            {
              var deleteResult = await _categoryRepository.DeleteEntityAsync(category);
              return deleteResult;
            }
            catch (Exception e)
            {
                return OperationResult.Failure("An error ocurred deleting the room category " + e.Message);
            }
    }

    public async Task<OperationResult> Save(SaveRoomCategoryDto dto)
    {
        var validResult = await _saveValidator.ValidateAsync(dto);
        if (!validResult.IsValid)
            return OperationResult.Failure("Validation failed: " + string.Join(", ", validResult.Errors.Select(e => e.ErrorMessage)));
        
        var categoryExists = await _categoryRepository.CategoryNameExistsAsync(dto.Name);
        if (categoryExists)
            return OperationResult.Failure("A room category with this name already exists");
    

        var category = dto.SaveRoomCategoryDtoToEntity();
        var saveResult = await _categoryRepository.SaveEntityAsync(category);

        return saveResult.isSuccess
            ? OperationResult.Success("Room category saved successfully", category.RoomCategoryToDto())
            : OperationResult.Failure("An error ocurred saving the room category");
       
    }

    public async Task<OperationResult> Update(UpdateRoomCategoryDto dto)
    {
        var categoryExists = await _categoryRepository.GetEntityByIdAsync(dto.Id);
        if(categoryExists.isSuccess )
            return OperationResult.Failure("Room category not found");

        var validResult = await _updateValidator.ValidateAsync(dto);
        if (!validResult.IsValid)
            return OperationResult.Failure("Validation failed: " + string.Join(", ", validResult.Errors.Select(e => e.ErrorMessage)));
            
        var category = dto.UpdateRoomCategoryDtoToEntity();
        var updateResult = await _categoryRepository.UpdateEntityAsync(category);

        return updateResult.isSuccess
            ? OperationResult.Success("Room category updated successfully", category.RoomCategoryToDto())
            : OperationResult.Failure("An error ocurred updating the room category");
    }
}

