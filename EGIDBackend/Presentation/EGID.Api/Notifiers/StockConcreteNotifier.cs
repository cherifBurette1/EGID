using EGID.Service.Features.Common.Interfaces.Notifiers;
using Microsoft.AspNetCore.SignalR;
using EGID.Api.SignalRHubs;
using System;

namespace EGID.Api.Notifiers
{
    /// <summary>
    /// StocksConcreteNotifier
    /// </summary>
    public class StockConcreteNotifier : IStockNotifier
    {
        private readonly Lazy<IHubContext<StocksHub>> _stocksHub;
        /// <summary>
        /// StocksConcreteNotifier
        /// </summary>
        /// <param name="stocksHub"></param>
        public StockConcreteNotifier(Lazy<IHubContext<StocksHub>> stocksHub)
        {
            _stocksHub = stocksHub;
        }
        private IHubContext<StocksHub> stocksHub => _stocksHub.Value;
    }
}
