using Mapster;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Movies;
using VideoTheque.Constants;
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
        public async Task<List<MovieViewModel>> GetMovies() => (await _moviesBusiness.GetMovies()).Select(c => new MovieViewModel
        {
            Id = c.Id,
            Director = c.Director,
            Scenarist = c.Scenarist,
            Duration = c.Duration,
            Support = EnumSupports.BluRays.ToString(),
            AgeRating = c.AgeRating,
            Genre = c.Genre,
            Title = c.Title,
            FirstActor = c.FirstActor
        }).ToList();

        [HttpGet("{partenaire}")]
        public async Task<List<MovieViewModel>> GetMovies([FromRoute] int partenaire) => (await _moviesBusiness.GetMovies(partenaire)).Select(c => new MovieViewModel
        {
            Id = c.Id,
            Director = c.Director,
            Scenarist = c.Scenarist,
            Duration = c.Duration,
            Support = EnumSupports.BluRays.ToString(),
            AgeRating = c.AgeRating,
            Genre = c.Genre,
            Title = c.Title,
            FirstActor = c.FirstActor
        }).ToList();

        [HttpGet("{id}")]
        public async Task<MovieViewModel> GetMovie([FromRoute] int id)
        {
            var movie = await _moviesBusiness.GetMovie(id);
            return new MovieViewModel
            {
                Id = movie.Id,
                Director = movie.Director,
                Scenarist = movie.Scenarist,
                Duration = movie.Duration,
                Support = EnumSupports.BluRays.ToString(),
                AgeRating = movie.AgeRating,
                Genre = movie.Genre,
                Title = movie.Title,
                FirstActor = movie.FirstActor
            };
        }


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