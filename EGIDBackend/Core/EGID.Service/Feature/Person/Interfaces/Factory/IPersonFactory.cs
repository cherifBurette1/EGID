using EGID.DTO.Models;

namespace EGID.Service.Features.Person.Interfaces.Factories
{
    public interface IPersonFactory
    {
        DTOPerson CreatePersonDTO(Data.Entities.Person stock);
    }
}
