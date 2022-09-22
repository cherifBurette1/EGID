using EGID.Language.Resources;
using EGID.Service.Feature.Stocks.Interfaces.Validators;
using EGID.Service.Models;
using EGID.Service.ServicesHelper;
using System.Threading.Tasks;

namespace Qorrect.Presistance.Features.Users.Implementation.Validators
{
    public class StockValidator : IStockValidator
    {
        public async Task<ValidatorResult> IsStockIdAvailable(int stockId)
        {
            if (stockId == 0)
            {
                return await ValidatorResultHelper.Error(
                    Resource.StockNotFound
                );
            }
            return await ValidatorResultHelper.Success<ValidatorResult>();
        }
    }
}