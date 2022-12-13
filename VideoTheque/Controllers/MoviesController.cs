using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Movies;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("films")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesBusiness _moviesBusiness;
        protected readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger, IMoviesBusiness moviesBusiness)
        {
            _logger = logger;
            _moviesBusiness = moviesBusiness;
        }

        [HttpGet]
        public async Task<List<MovieViewModel>> GetMovies() => (await _moviesBusiness.GetMovies()).Adapt<List<MovieViewModel>>();

        [HttpGet("{id}")]
        public async Task<MovieViewModel> GetMovie([FromRoute] int id) => _moviesBusiness.GetMovie(id).Adapt<MovieViewModel>();

        [HttpPost]
        public async Task<IResult> InsentMovie([FromBody] MovieViewModel movieVM)
        {
            var created = _moviesBusiness.InsertMovie(movieVM.Adapt<FilmDto>());
            return Results.Created($"/films/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateMovie([FromRoute] int id, [FromBody] MovieViewModel movieVM)
        {
            _moviesBusiness.UpdateMovie(id, movieVM.Adapt<FilmDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteMovie([FromRoute] int id)
        {
            _moviesBusiness.DeleteMovie(id);
            return Results.Ok();
        }
    }
}
