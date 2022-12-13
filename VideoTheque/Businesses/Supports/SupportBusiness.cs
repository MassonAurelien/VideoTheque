using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Constants;
using VideoTheque.Repositories.Supports;
using VideoTheque.Supports.ISupportsBusiness;

namespace VideoTheque.Business.Supports
{
    public class SupportsBusiness : ISupportsBusiness
    {
        private readonly ISupportsRepository _SupportsRepository;
        public SupportsBusiness(ISupportsRepository SupportsRepository)
        {
            _SupportsRepository = SupportsRepository;
        }

        public List<SupportsDto> GetSupports() => _SupportsRepository.GetSupports();

        public SupportsDto GetSupport(int id)
        {
            var Support = _SupportsRepository.GetSupport(id);

            if (Support == null)
            {
                throw new NotFoundException($"Support '{id}' non trouvé");
            }

            return Support;
        }
             
    }
}
