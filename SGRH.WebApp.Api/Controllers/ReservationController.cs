using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Dtos.Person.Reservation;
using SGRH.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGRH.WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _reservationService.GetAll();

            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _reservationService.GetById(id);

            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // POST api/<ReservationController>
        [HttpPost("CreateReservation")]
        public async Task<IActionResult> Post([FromBody] SaveReservationDto dto)
        {
            var result = await _reservationService.Save(dto);

            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // PUT api/<ReservationController>/5
        [HttpPut("UpdateReservation")]
        public async Task<IActionResult> Put([FromBody] UpdateReservationDto dto)
        {
            var result = await _reservationService.Update(dto);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
