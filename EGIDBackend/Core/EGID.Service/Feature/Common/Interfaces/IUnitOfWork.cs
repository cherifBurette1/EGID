using System.Threading.Tasks;
using EGID.Service.Features.Broker.Interfaces.Repositories;
using EGID.Service.Features.Orders.Interfaces.Repositories;
using EGID.Service.Features.Person.Interfaces.Repositories;
using EGID.Service.Features.Stocks.Interfaces.Repositories;

namespace EGID.Service.Features.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(bool enableAuditLog = true);
        IDatabaseTransaction BeginTransaction();
        #region Repositories
        IStockRepository StockRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPersonRepository PersonRepository { get; }
        IBrokerRepository BrokerRepository { get; }
        #endregion
    }
}