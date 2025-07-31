using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Dtos.RoomCategory;
using SGRH.Application.Interfaces;
using SGRH.WebApp.Api.Controllers.Base;

namespace SGRH.WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly IRoomCategoryService _categoryService;

        public CategoryController(IRoomCategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAll();
            return HandleOperationResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetById(id);
            return HandleOperationResult(result);
        }
        
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Post([FromBody] SaveRoomCategoryDto dto)
        {
            var result = await _categoryService.Save(dto);
            return HandleOperationResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateRoomCategoryDto dto)
        {
            var result = await _categoryService.Update(dto);
            return HandleOperationResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Remove(id);
            return HandleOperationResult(result);
        }
    }
}
