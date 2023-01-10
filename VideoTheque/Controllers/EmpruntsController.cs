using Mapster;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Emprunts;
using VideoTheque.Constants;
using VideoTheque.ViewModels;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("emprunts")]
    public class EmpruntsController : ControllerBase
    {
        private readonly IEmpruntsBusiness _empruntsBusiness;
        protected readonly ILogger<EmpruntsController> _logger;

        public EmpruntsController(ILogger<EmpruntsController> logger, IEmpruntsBusiness empruntsBusiness)
        {
            _logger = logger;
            _empruntsBusiness = empruntsBusiness;
        }

        [HttpGet]
        public async Task<List<MovieViewModel>> GetMovies() => (await _empruntsBusiness.GetFilms()).Select(c => new MovieViewModel
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

        [HttpPost("{id}")]
        public async Task<EmpruntsViewModel> PostMovie([FromRoute] int id)
        {
            var movie = await _empruntsBusiness.PostFilm(id);
            return new EmpruntsViewModel
            {
                Id = movie.Id,
                Director = movie.Director.Adapt<PersonneViewModel>(),
                Scenarist = movie.Scenarist.Adapt<PersonneViewModel>(),
                Duration = movie.Duration,
                Support = EnumSupports.BluRays.ToString(),
                AgeRating = movie.AgeRating.Adapt<AgeRatingModel>(),
                Genre = movie.Genre.Adapt<GenreViewModel>(),
                Title = movie.Title,
                FirstActor = movie.FirstActor.Adapt<PersonneViewModel>()
            };
        }

        [HttpDelete("{name}")]
        public async Task<IResult> DeleteMovie([FromRoute] string name)
        {
            _empruntsBusiness.DeleteFilm(name);
            return Results.Ok();
        }
    }
}
