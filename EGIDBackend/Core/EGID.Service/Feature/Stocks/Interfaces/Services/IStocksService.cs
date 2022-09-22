using EGID.Service.Models;
using System.Threading.Tasks;
using EGID.DTO.Models;

namespace EGID.Service.Feature.Stocks.Interfaces.Services
{
    public interface IStocksService
    {
        public Task<ServiceResultList<DTOStock>> GetStocks();
        public Task<ServiceResultDetail<DTOStock>> GetCertainStock(int stockId);
        Task<ServiceResultList<DTOStock>> UpdateAndGetStocks();
    }
}