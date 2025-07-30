using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Dtos.RoomCategory;
using SGRH.Application.Interfaces;

namespace SGRH.WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRoomCategoryService _categoryService;

        public CategoryController(IRoomCategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAll();

            if (!result.isSuccess)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetById(id);

            if (!result.isSuccess)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }
        
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Post([FromBody] SaveRoomCategoryDto dto)
        {
            var result = await _categoryService.Save(dto);

            if (!result.isSuccess)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateRoomCategoryDto dto)
        {
            var result = await _categoryService.Update(dto);
            if (!result.isSuccess)
            {
                return NotFound(result);
            }
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Remove(id);

            if (!result.isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
