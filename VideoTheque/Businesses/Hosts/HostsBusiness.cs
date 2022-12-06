using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Hosts;

namespace VideoTheque.Businesses.Hosts
{
    public class HostsBusiness : IHostsBusiness
    {

        private readonly IHostsRepository _hostsDao;

        public HostsBusiness(IHostsRepository hostsDao)
        {
            _hostsDao = hostsDao;
        }

        public Task<List<HostDto>> GetHosts() => _hostsDao.GetHosts();

        

        public HostDto GetHost(int id)
        {
            var hosts = _hostsDao.GetHost(id).Result;

            if (hosts == null)
            {
                throw new NotFoundException($"Host '{id}' non trouvé");
            }

            return  hosts;
        }

        public HostDto InsertHost(HostDto hosts)
        {
            if (_hostsDao.InsertHost(hosts).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion de l'host {hosts.Name}");
            }

            return hosts;
        }

        public void UpdateHost(int id, HostDto hosts)
        {
            if (_hostsDao.UpdateHost(id, hosts).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification de l'host {hosts.Name}");
            }
        }

        public void DeleteHost(int id)
        {
            if (_hostsDao.DeleteHost(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression de l'host : {id}");
            }
        }
    }
}
