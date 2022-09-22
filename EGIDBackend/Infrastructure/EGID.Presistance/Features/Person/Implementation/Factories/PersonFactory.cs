using EGID.DTO.Models;
using EGID.Service.Features.Person.Interfaces.Factories;

namespace EGID.Presistance.Features.Person.Implementation.Factories
{
    public class BrokerFactory : IPersonFactory
    {
        public DTOPerson CreatePersonDTO(Data.Entities.Person person)
        {
            return new DTOPerson()
            {
                Id = person.Id,
                Name = person.Name
            };
        }

    }
}
