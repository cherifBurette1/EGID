using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Service.Features.Broker.Interfaces.Repositories
{
    public interface IBrokerRepository
    {
        Task<List<Data.Entities.Broker>> GetBrokersList();
    }
}
