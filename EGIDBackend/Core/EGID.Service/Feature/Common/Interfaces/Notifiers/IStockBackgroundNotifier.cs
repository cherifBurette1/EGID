using System.Threading.Tasks;

namespace EGID.Service.Features.Common.Interfaces.Notifiers
{
    public interface IStockBackgroundNotifier
    {
        Task GetStocks();
        Task GetCertainStock(int stockId);
    }

}
