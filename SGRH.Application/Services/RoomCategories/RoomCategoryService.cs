using System;
using Microsoft.Extensions.Logging;
using SGRH.Application.Dtos.RoomCategory;
using SGRH.Application.Interfaces;
using SGRH.Application.Mappers;
using SGRH.Domain.Base;
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
            var dtos = categories.RoomCategoriesToDto();
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
            var category = await _categoryRepository.GetEntityByIdAsync(Id);
            var dto = category.RoomCategoryToDto();
            return OperationResult.Success("Room category found successfully", dto);
        }
        catch (Exception e)
        {
           ValidationRepository.LogError(_logger, $"Error retrieving category {Id}: {e.Message}");
            return OperationResult.Failure("An error ocurred finding the room category");
        }
    }

    public async Task<OperationResult> Remove(RemoveRoomCategoryDto dto)
    {
        try
        {
            var category = await _categoryRepository.GetEntityByIdAsync(dto.Id);
            if (category.Rooms?.Any() == true)
                return OperationResult.Failure("Rooms associated with this category cannot be deleted");

            var result = await _categoryRepository.DeleteEntityAsync(category);
            ValidationRepository.LogInformation(_logger, "Deleted Successfully");

            dto.Removed = true;
            dto.ChangeDate = DateTime.UtcNow;

            return OperationResult.Success("Room category deleted successfully", dto);
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
            var category = dto.SaveRoomCategoryDtoToEntity();
            var result = await _categoryRepository.SaveEntityAsync(category);
            return OperationResult.Success("Room category saved successfully", category.RoomCategoryToDto());
        }
        catch (Exception e)
        {
            ValidationRepository.LogError(_logger, $"Error saving room category: {e.Message}");
            return OperationResult.Failure("An error ocurred saving the room category");
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
