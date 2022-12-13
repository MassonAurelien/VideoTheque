using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoTheque.DTOs;
using VideoTheque.ViewModels;
using Mapster;
using VideoTheque.Supports.ISupportsBusiness;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("supports")]
    public class SupportsController : ControllerBase
    {
        protected readonly ILogger<SupportsController> _logger;
        private readonly ISupportsBusiness _SupportsBusiness;

        public SupportsController(ILogger<SupportsController> logger, ISupportsBusiness SupportsBusiness)
        {
            _logger = logger;
            _SupportsBusiness = SupportsBusiness;
        }

        [HttpGet]
        public List<SupportsViewModel> GetSupports() => (_SupportsBusiness.GetSupports()).Adapt<List<SupportsViewModel>>();

        [HttpGet("{id}")]
        public SupportsViewModel GetSupport([FromRoute] int id) => _SupportsBusiness.GetSupport(id).Adapt<SupportsViewModel>();

    }
}
