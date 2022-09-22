using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EGID.Service.Feature.Person.Interfaces.Services;

namespace EGID.Api.Controllers
{
    public class PersonController : BaseController
    {
        private readonly Lazy<IPersonService> _personService;
        /// <summary>
        /// Academic-Level Constructor
        /// </summary>
        /// <param name="stocksService"></param>
        public PersonController(Lazy<IPersonService> personService)
        {
            _personService = personService;
        }
        /// <summary>
        /// Get list of stocks
        /// </summary>
        /// <returns>list of stocks</returns>
        private IPersonService PersonService => _personService.Value;
        [HttpGet("person", Name = "GetPersons")]
        public async Task<IActionResult> GetPersons()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await PersonService.GetPersonsList();
            return GetApiResponse(result);
        }
    }
}