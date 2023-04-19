using APIHotel.Data.Repositories;
using APIHotel.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        //1.	Método que devuelva un listado de Hoteles, lista completa sin filtros.
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return Ok(await _hotelRepository.GetAllHotels());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _hotelRepository.GetDetails(id));
        }

        //**********************************************************************

        //2.	Método para listar los hoteles filtrando por: Categoría, por calificaciones
        [HttpGet("Filter")]
        public async Task<IActionResult> FilterHotels(string categoria, int? minCalificacion, int? maxCalificacion)
        {
            var filteredHotels = await _hotelRepository.FilterHotels(categoria, minCalificacion, maxCalificacion);

            return Ok(filteredHotels);
        }

        //**********************************************************************

        //3.	Método que devuelva los hoteles ordenados por Precio (de mayor a menor y/o viceversa).
        [HttpGet("Sort")]
        public async Task<IActionResult> SortHotels(string sortBy = "asc")
        {
            var sortedHotels = await _hotelRepository.SortHotels(sortBy);

            return Ok(sortedHotels);
        }

        //**********************************************************************

        //4.	Métodos para todo el CRUD de hoteles.
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _hotelRepository.InsertHotel(hotel);

            return Created("created", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            if (hotel == null || hotel.hotelid != id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _hotelRepository.UpdateHotel(hotel);

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(new Hotel { hotelid = id });

            return NoContent();
        }

        //**********************************************************************

    }
}
