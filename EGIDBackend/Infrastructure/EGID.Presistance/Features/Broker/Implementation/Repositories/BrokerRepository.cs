using EGID.Service.Features.Broker.Interfaces.Repositories;
using EGID.Service.Features.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EGID.Presistance.Features.Broker.Implementation.Repositories
{
    public class BrokerRepository : IBrokerRepository
    {
        private readonly IEGIDEntities _EGIDEntities;
        public BrokerRepository(IEGIDEntities eGIDEntities)
        {
            _EGIDEntities = eGIDEntities;
        }

        public async Task<List<Data.Entities.Broker>> GetBrokersList()
        {
            return await _EGIDEntities.Brokers.ToListAsync();
        }
    }
}
