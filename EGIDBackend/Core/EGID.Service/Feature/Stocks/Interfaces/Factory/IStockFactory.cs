using EGID.Data.Entities;
using EGID.DTO.Models;

namespace EGID.Service.Features.Stocks.Interfaces.Factories
{
    public interface IStockFactory
    {
        DTOStock CreateStockDTO(Stock stock);
    }
}
