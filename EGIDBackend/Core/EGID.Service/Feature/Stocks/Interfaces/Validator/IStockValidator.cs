using EGID.Service.Models;
using System.Threading.Tasks;

namespace EGID.Service.Feature.Stocks.Interfaces.Validators
{
    public interface IStockValidator
    {
        Task<ValidatorResult> IsStockIdAvailable(int stockId);
    }
}
