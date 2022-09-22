using EGID.Data.Entities;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Stocks.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EGID.Presistance.Features.Stocks.Implementation.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IEGIDEntities _EGIDEntities;
        public StockRepository(IEGIDEntities eGIDEntities)
        {
            _EGIDEntities = eGIDEntities;
        }

        public async Task<Stock> GetCertainStock(int stockId)
        {
            return await _EGIDEntities.Stocks.FirstOrDefaultAsync(x => x.Id == stockId);
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _EGIDEntities.Stocks.ToListAsync();
        }
    }
}
