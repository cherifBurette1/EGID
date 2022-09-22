using Microsoft.AspNetCore.Mvc;
using EGID.DTO.Models;
using System;
using System.Threading.Tasks;
using EGID.Service.Feature.Broker.Interfaces.Services;

namespace EGID.Api.Controllers
{
    public class BrokerController : BaseController
    {
        private readonly Lazy<IBrokerService> _brokerService;
        /// <summary>
        /// Academic-Level Constructor
        /// </summary>
        /// <param name="brokerService"></param>
        public BrokerController(Lazy<IBrokerService> brokerService)
        {
            _brokerService = brokerService;
        }
        /// <summary>
        /// Get list of brokers
        /// </summary>
        /// <returns>list of brokers</returns>
        private IBrokerService BrokerService => _brokerService.Value;
        [HttpGet("brokers", Name = "GetBrokers")]
        public async Task<IActionResult> GetBrokers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await BrokerService.GetBrokersList();
            return GetApiResponse(result);
        }
    }
}