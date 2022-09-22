using EGID.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Service.Features.Stocks.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocks();

        Task<Stock> GetCertainStock(int StockId);
    }
}
