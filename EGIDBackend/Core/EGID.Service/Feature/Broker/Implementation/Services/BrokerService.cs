using EGID.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using EGID.Service.Features.Common.Interfaces;
using EGID.DTO.Models;
using EGID.Service.Features.Broker.Interfaces.Factories;
using EGID.Service.Feature.Broker.Interfaces.Services;

namespace Qorrect.Service.Feature.Broker.Implementation.Services
{
    public class BrokerService : IBrokerService
    {
        private readonly Lazy<IBrokerFactory> _brokerFactory;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        public BrokerService(Lazy<IBrokerFactory> BrokerFactory,
            Lazy<IUnitOfWork> unitOfWork)
        {
            _brokerFactory = BrokerFactory;
            _unitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IBrokerFactory brokerFactory => _brokerFactory.Value;

        public async Task<ServiceResultList<DTOBroker>> GetBrokersList()
        {
            var data = await UnitOfWork.BrokerRepository.GetBrokersList();
            var dtos = data.Select(x => brokerFactory.CreateBrokerDTO(x)).ToList();
            return new ServiceResultList<DTOBroker>()
            {
                Model = dtos,
                IsValid = true
            };
        }
    }
}