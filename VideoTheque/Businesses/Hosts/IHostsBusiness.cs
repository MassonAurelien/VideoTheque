using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Hosts
{
    public interface IHostsBusiness
    {
        Task<List<HostDto>> GetHosts();

        HostDto GetHost(int id);

        HostDto InsertHost(HostDto ageRating);

        void UpdateHost(int id, HostDto ageRating);

        void DeleteHost(int id);
    }
}
