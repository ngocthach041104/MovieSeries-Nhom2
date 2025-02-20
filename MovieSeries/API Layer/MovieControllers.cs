using Microsoft.AspNetCore.Mvc;
using Pj.CoreLayer.Entities;
using Pj.ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace Pj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movie
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        // GET: api/movie/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound($"Movie with Id={id} not found.");
            }
            return Ok(movie);
        }

        // POST: api/movie
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            await _movieService.AddMovieAsync(movie);
            // Có thể dùng CreatedAtAction để trả về link chi tiết
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }


        // PUT: api/movie/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("Movie ID mismatch.");
            }

            await _movieService.UpdateMovieAsync(movie);
            return NoContent(); // 204
        }

        // DELETE: api/movie/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent(); // 204
        }

        // GET: api/movie/top-rated/{count}
        [HttpGet("top-rated/{count}")]
        public async Task<IActionResult> GetTopRatedMovies(int count)
        {
            var movies = await _movieService.GetTopRatedMoviesWithSpAsync(count);
            return Ok(movies);
        }
    }
}
