using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Supports
{
    public interface ISupportsRepository
    {
        List<SupportsDto> GetSupports();

        SupportsDto GetSupport(int id);

    }
}
