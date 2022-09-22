using Microsoft.AspNetCore.SignalR;
using EGID.HangfireServer.SignalRHubs;
using EGID.Service.Features.Common.Interfaces.Notifiers;
using System;
using System.Threading.Tasks;

namespace EGID.HangfireServer.Notifiers
{
    public class StockBackgroundConcreteNotifier : IStockBackgroundNotifier
    {
        private readonly Lazy<IHubContext<StocksHub>> _stockHub;
        public StockBackgroundConcreteNotifier(Lazy<IHubContext<StocksHub>> sotckHub)
        {
            _stockHub = sotckHub;
        }
        private IHubContext<StocksHub> StockHub => _stockHub.Value;

        public async Task GetStocks()
        {
            await StockHub.Clients.Group($"Stock").SendAsync("MonitorMissedExam");
        }
        public async Task GetCertainStock(int stockId)
        {

            await StockHub.Clients.Group($"Stock/{ stockId }").SendAsync("MonitorMissedExam");
        }
    }
}
