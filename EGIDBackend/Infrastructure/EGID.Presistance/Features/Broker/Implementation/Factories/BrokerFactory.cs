using EGID.DTO.Models;
using EGID.Service.Features.Broker.Interfaces.Factories;

namespace EGID.Presistance.Features.Broker.Implementation.Factories
{
    public class BrokerFactory : IBrokerFactory
    {
        public DTOBroker CreateBrokerDTO(Data.Entities.Broker broker)
        {
            return new DTOBroker()
            {
                Id = broker.Id,
                Name = broker.Name
            };
        }

    }
}
