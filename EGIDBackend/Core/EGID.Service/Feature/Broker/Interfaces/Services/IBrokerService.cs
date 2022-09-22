using EGID.Service.Models;
using System.Threading.Tasks;
using EGID.DTO.Models;

namespace EGID.Service.Feature.Broker.Interfaces.Services
{
    public interface IBrokerService
    {
        public Task<ServiceResultList<DTOBroker>> GetBrokersList();
    }
}