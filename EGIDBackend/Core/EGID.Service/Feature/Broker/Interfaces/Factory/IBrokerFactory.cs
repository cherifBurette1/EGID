using EGID.DTO.Models;

namespace EGID.Service.Features.Broker.Interfaces.Factories
{
    public interface IBrokerFactory
    {
        DTOBroker CreateBrokerDTO(Data.Entities.Broker broker);
    }
}
