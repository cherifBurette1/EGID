using EGID.Service.Feature.Stocks.Interfaces.Services;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace EGID.HangfireServer.SignalRHubs
{
    public class StocksHub : Hub
    {
        private IStocksService _stocksService;
        protected IHubContext<StocksHub> _context;

        public StocksHub(IStocksService stocksService, IHubContext<StocksHub> context)
        {
            if (stocksService == null)
            {
                throw new ArgumentNullException("stocksService");
            }
            _stocksService = stocksService;
            _context = context;
        }
        /// <summary>
        /// GetStocks
        /// </summary>
        /// <returns>Get Stocks</returns>
        public async Task GetStocks()
        {
            var result = await _stocksService.GetStocks();
                await _context.Clients.All.SendAsync("GetStocksResponse", result.Model);
            RecurringJob.AddOrUpdate("updateAndGetStockss", () => GetStocks(), "*/10 * * * * *");
        }
        /// <summary>
        /// Get Certain Stock
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns>Get Certain Stock</returns>
        public async Task GetCertainStock(int stockId)
        {
            var result = await _stocksService.GetCertainStock(stockId);
            await Clients.Clients(Context.ConnectionId).SendAsync($"Stock/{stockId}", result);
        }
    }
}
