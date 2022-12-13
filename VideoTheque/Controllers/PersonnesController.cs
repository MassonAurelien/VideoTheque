using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Personnes;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;
using Mapster;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("personnes")]
    public class PersonnesController : ControllerBase
    {
        protected readonly ILogger<PersonnesController> _logger;
        private readonly IPersonnesBusiness _PersonnesBusiness;

        public PersonnesController(ILogger<PersonnesController> logger, IPersonnesBusiness PersonnesBusiness)
        {
            _logger = logger;
            _PersonnesBusiness = PersonnesBusiness;
        }

        [HttpGet]
        public async Task<List<PersonneViewModel>> GetPersonnes() => (await _PersonnesBusiness.GetPersonnes()).Adapt<List<PersonneViewModel>>();

        [HttpGet("{id}")]
        public async Task<PersonneViewModel> GetPersonne([FromRoute] int id) => _PersonnesBusiness.GetPersonne(id).Adapt<PersonneViewModel>();

        [HttpPost]
        public async Task<IResult> InsentPersonne([FromBody] PersonneViewModel PersonneVM)
        {
            var created = _PersonnesBusiness.InsertPersonne(PersonneVM.Adapt<PersonneDto>());
            return Results.Created($"/Personnes/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdatePersonne([FromRoute] int id, [FromBody] PersonneViewModel PersonneVM)
        {
            _PersonnesBusiness.UpdatePersonne(id, PersonneVM.Adapt<PersonneDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeletePersonne([FromRoute] int id)
        {
            _PersonnesBusiness.DeletePersonne(id);
            return Results.Ok();
        }
    }
}
