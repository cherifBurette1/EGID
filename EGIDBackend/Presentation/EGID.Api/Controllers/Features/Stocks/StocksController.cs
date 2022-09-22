using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EGID.Service.Feature.Stocks.Interfaces.Services;

namespace EGID.Api.Controllers
{
    public class StocksController : BaseController
    {
        private readonly Lazy<IStocksService> _stocksService;
        /// <summary>
        /// Academic-Level Constructor
        /// </summary>
        /// <param name="stocksService"></param>
        public StocksController(Lazy<IStocksService> stocksService)
        {
            _stocksService = stocksService;
        }
        /// <summary>
        /// Get list of stocks
        /// </summary>
        /// <returns>list of stocks</returns>
        private IStocksService StocksService => _stocksService.Value;
        [HttpGet("stocks", Name = "GetStocks")]
        public async Task<IActionResult> GetStocks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await StocksService.GetStocks();
            return GetApiResponse(result);
        }
    }
}