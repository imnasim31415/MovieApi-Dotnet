using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]   // defines base URL... api/movie. [Controller] = MovieController (class name) - Controller
    [ApiController]  // indicates this is an REST API controller
    public class MovieController : ControllerBase // not Controller (no views)
    {
        private readonly MovieContext _context; // _context represents DB session
        public MovieController(MovieContext context) => _context = context; // Registers DbContext with DI container

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() =>
            await _context.Movies.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
