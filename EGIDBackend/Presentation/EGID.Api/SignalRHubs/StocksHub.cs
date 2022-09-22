using EGID.Service.Feature.Stocks.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace EGID.Api.SignalRHubs
{

    public class StocksHub : Hub
    {
        private readonly Lazy<IStocksService> _stocksService;
        /// <summary>
        /// Academic-Level Constructor
        /// </summary>
        /// <param name="stocksService"></param>
        public StocksHub(Lazy<IStocksService> stocksService)
        {
            _stocksService = stocksService;
        }
        private IStocksService StockService => _stocksService.Value;
        /// <summary>
        /// GetStocks
        /// </summary>
        /// <returns>Get Stocks</returns>
        public async Task GetStocks()
        {
            var result = await StockService.GetStocks();
            await Clients.Clients(Context.ConnectionId).SendAsync("Stocks", result);
        }
        /// <summary>
        /// Get Certain Stock
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns>Get Certain Stock</returns>
        public async Task GetCertainStock(int stockId)
        {
            var result = await StockService.GetCertainStock(stockId);
            await Clients.Clients(Context.ConnectionId).SendAsync("Stock", result);
        }
    }
}
