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
    public RoomCategoryService(IRoomCategoryRepository roomCategoryRepository,
                                ILogger<RoomCategoryService> logger)
    {
        _categoryRepository = roomCategoryRepository;
        _logger = logger;
    }
    public async Task<OperationResult> GetAll()
    {
        try
        {   
            var categories = await _categoryRepository.GetAllAsync();
            var dtos = RoomCategoryMapper.RoomCategoriesToDto(categories.Data);

            return OperationResult.Success("Room categories found successfully", dtos);
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error retrieving all categories: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the room categories");
        }
    }

    public async Task<OperationResult> GetById(int Id)
    {
        try
        {
            
            var result = await _categoryRepository.GetEntityByIdAsync(Id);
            var category = result.Data as RoomCategory;
            var dto = RoomCategoryMapper.RoomCategoryToDto(category);

            return OperationResult.Success("Room category found successfully", dto);
        }
        catch (Exception e)
        {
           ValidationRepository.LogError(_logger, $"Error retrieving category {Id}: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the room category");
        }
    }

    public async Task<OperationResult> Remove(int id)
    {
        try
        {
            var result = await _categoryRepository.GetEntityByIdAsync(id);
            var category = result.Data as RoomCategory;
            ValidationRepository.ValidateEntity(category, _logger, "Category doesn't exist");


            await _categoryRepository.DeleteEntityAsync(category);

            return OperationResult.Success("Room category deleted successfully");
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error deleting room category: {e.Message}");
            return OperationResult.Failure("An error ocurred deleting the room category");
        }
    }

    public async Task<OperationResult> Save(SaveRoomCategoryDto dto)
    {
        try
        {
            var isBlank = ValidationRepository.ValidateStringEmpty(dto.Name, "Name", _logger);
            if (!isBlank.isSuccess)
            {
                return isBlank;
            }

            var nameExists = await _categoryRepository.ExistsAsync(c => c.Name == dto.Name);
            if (nameExists.Data){
                return OperationResult.Failure("A room category with this name already exists");
            }

            if (dto.NightlyRate <= 0)
            {
                return OperationResult.Failure("Nightly rate must be a positive number");
            }

            var category = dto.SaveRoomCategoryDtoToEntity();
            var result = await _categoryRepository.SaveEntityAsync(category);
            return OperationResult.Success("Room category saved successfully", category.RoomCategoryToDto());
        }
        catch (Exception e)
        {
            return OperationResult.Failure("An error ocurred saving the room category: " + e.Message);
        }
    }

    public async Task<OperationResult> Update(UpdateRoomCategoryDto dto)
    {
        try
        {
            var category = dto.UpdateRoomCategoryDtoToEntity();
            var result =  await _categoryRepository.UpdateEntityAsync(category);
            return OperationResult.Success("Room category updated successfully", result.Data?.RoomCategoryToDto());
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error updating room category: {e.Message}");
            return OperationResult.Failure("An error ocurred updating the room category");
        }
    }
}
