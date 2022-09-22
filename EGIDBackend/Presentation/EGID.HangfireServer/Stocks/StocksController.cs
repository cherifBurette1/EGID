using Microsoft.AspNetCore.Mvc;
using EGID.DTO.Models;
using System;
using System.Threading.Tasks;
using EGID.Service.Feature.Stocks.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using Hangfire;

namespace EGID.Api.Controllers
{
    public class StocksController : BaseController
    {
        private readonly Lazy<IStocksService> _stocksService;
        private readonly IHubContext<HangfireServer.SignalRHubs.StocksHub> _hub;

        /// <summary>
        /// Academic-Level Constructor
        /// </summary>
        /// <param name="stocksService"></param>
        public StocksController(Lazy<IStocksService> stocksService, IHubContext<HangfireServer.SignalRHubs.StocksHub> hub)
        {
            _stocksService = stocksService;
            _hub = hub;
        }
        /// <summary>
        /// Get list of stocks
        /// </summary>
        /// <returns>list of stocks</returns>
        private IStocksService StocksService => _stocksService.Value;
        [HttpGet("stocks", Name = "GetStocks")]
        public async Task<IActionResult> GetStocks(string trigger)
        {
            RecurringJob.AddOrUpdate("updateAndGetStockss", () => GetStocks("hi"), "*/10 * * * * *");
            var result = await StocksService.GetStocks();
            await _hub.Clients.All.SendAsync("GetStocksResponse", result);
            return GetApiResponse(result);
        }
    }
}