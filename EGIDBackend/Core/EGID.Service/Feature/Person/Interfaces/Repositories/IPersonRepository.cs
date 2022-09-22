using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Service.Features.Person.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Data.Entities.Person>> GetPersonsList();
    }
}
