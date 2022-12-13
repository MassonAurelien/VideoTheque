using VideoTheque.DTOs;

namespace VideoTheque.Supports.ISupportsBusiness
{
    public interface ISupportsBusiness
    {
        List<SupportsDto> GetSupports();

        SupportsDto GetSupport(int id);

    }
}
