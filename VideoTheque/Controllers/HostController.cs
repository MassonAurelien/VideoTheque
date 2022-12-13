using Mapster;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Hosts;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("hosts")]
    public class HostController : ControllerBase
    {
        private readonly IHostsBusiness _hostBusiness;
        protected readonly ILogger<HostController> _logger;

        public HostController(IHostsBusiness hostBusiness, ILogger<HostController> logger)
        {
            _hostBusiness = hostBusiness;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<HostModel>> GetHosts() => (await _hostBusiness.GetHosts()).Adapt<List<HostModel>>();

        [HttpGet("{id}")]
        public async Task<HostModel> GetHost([FromRoute] int id) => _hostBusiness.GetHost(id).Adapt<HostModel>();

        [HttpPost]
        public async Task<IResult> InsertHost([FromBody] HostModel hostVM)
        {
            var created = _hostBusiness.InsertHost(hostVM.Adapt<HostDto>());
            return Results.Created($"/hosts/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateHost([FromRoute] int id, [FromBody] HostModel hostVM)
        {
            _hostBusiness.UpdateHost(id, hostVM.Adapt<HostDto>());
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteHost([FromRoute] int id)
        {
            _hostBusiness.DeleteHost(id);
            return Results.Ok();
        }
    }
}
