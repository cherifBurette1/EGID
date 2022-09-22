using EGID.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using EGID.Service.Features.Common.Interfaces;
using EGID.DTO.Models;
using EGID.Service.Feature.Person.Interfaces.Services;
using EGID.Service.Features.Person.Interfaces.Factories;

namespace Qorrect.Service.Feature.Person.Implementation.Services
{
    public class BrokerService : IPersonService
    {
        private readonly Lazy<IPersonFactory> _personFactory;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        public BrokerService(Lazy<IPersonFactory> PersonFactory,
            Lazy<IUnitOfWork> unitOfWork)
        {
            _personFactory = PersonFactory;
            _unitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IPersonFactory PersonFactory => _personFactory.Value;
        public async Task<ServiceResultList<DTOPerson>> GetPersonsList()
        {
            var data = await UnitOfWork.PersonRepository.GetPersonsList();
            var dtos = data.Select(x => PersonFactory.CreatePersonDTO(x)).ToList();
            return new ServiceResultList<DTOPerson>()
            {
                Model = dtos,
                IsValid = true
            };
        }
    }
}