using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Person.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EGID.Presistance.Features.Person.Implementation.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IEGIDEntities _EGIDEntities;
        public PersonRepository(IEGIDEntities eGIDEntities)
        {
            _EGIDEntities = eGIDEntities;
        }

        public async Task<List<Data.Entities.Person>> GetPersonsList()
        {
            return await _EGIDEntities.Persons.ToListAsync();
        }
    }
}
