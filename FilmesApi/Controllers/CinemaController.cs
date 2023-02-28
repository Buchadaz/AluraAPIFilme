using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmContext _context;
        private IMapper _mapper;

        public CinemaController(FilmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> LeituraCinema()
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult LeituraCinemaPorId(int id) 
        {Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();

        }




        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(LeituraCinemaPorId), //Retorna 201, item adicionado com sucesso.
            new { id = cinema.Id },
            cinema);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
