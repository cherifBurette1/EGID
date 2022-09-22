using EGID.Service.Models;
using System.Threading.Tasks;
using EGID.DTO.Models;

namespace EGID.Service.Feature.Person.Interfaces.Services
{
    public interface IPersonService
    {
        public Task<ServiceResultList<DTOPerson>> GetPersonsList();
    }
}