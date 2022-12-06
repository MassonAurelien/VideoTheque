using Mapster;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Age_rating;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("age-rating")]
    public class AgeRatingController : ControllerBase
    {
        private readonly IAgeRatingBusiness _ageRatingBusiness;
        protected readonly ILogger<AgeRatingController> _logger;

        public AgeRatingController(IAgeRatingBusiness ageRatingBusiness, ILogger<AgeRatingController> logger)
        {
            _ageRatingBusiness = ageRatingBusiness;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<AgeRatingModel>> GetAgeRatings() => (await _ageRatingBusiness.GetAgeRatings()).Adapt<List<AgeRatingModel>>();

        [HttpGet("{id}")]
        public async Task<AgeRatingModel> GetAgeRating([FromRoute] int id) => _ageRatingBusiness.GetAgeRating(id).Adapt<AgeRatingModel>();

        [HttpPost]
        public async Task<IResult> InsertAgeRating([FromBody] AgeRatingModel ageRatingVM)
        {
            var created = _ageRatingBusiness.InsertAgeRating(ageRatingVM.Adapt<AgeRatingDto>());
            return Results.Created($"/age-rating/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateAgeRating([FromRoute] int id, [FromBody] AgeRatingModel ageRatingVM)
        {
            _ageRatingBusiness.UpdateAgeRating(id,ageRatingVM.Adapt<AgeRatingDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteGenre([FromRoute] int id)
        {
            _ageRatingBusiness.DeleteAgeRating(id);
            return Results.Ok();
        }
    }
}
