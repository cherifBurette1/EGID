using System;
using System.Threading.Tasks;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Orders.Interfaces.Repositories;
using EGID.Service.Features.Broker.Interfaces.Repositories;
using EGID.Service.Features.Person.Interfaces.Repositories;
using EGID.Service.Features.Stocks.Interfaces.Repositories;

namespace EGID.Presistance.Features.Common.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        #region private fields
        private readonly IEGIDEntities _context;
        private readonly Lazy<IPersonRepository> personRepository;
        private readonly Lazy<IBrokerRepository> brokerRepository;
        private readonly Lazy<IStockRepository> stockRepository;
        private readonly Lazy<IOrderRepository> orderRepository;
        #endregion

        #region constructor
        public UnitOfWork(IEGIDEntities context,
            Lazy<IOrderRepository> orderRepository,
            Lazy<IStockRepository> stockRepository,
            Lazy<IPersonRepository> personRepository,
            Lazy<IBrokerRepository> brokerRepository
            )
        {
            _context = context;
            this.personRepository = personRepository;
            this.brokerRepository = brokerRepository;
            this.orderRepository = orderRepository;
            this.stockRepository = stockRepository;
        }

        #endregion

        #region Properties
        private IEGIDEntities EGIDEntities => _context;
        public IStockRepository StockRepository => stockRepository.Value;
        public IOrderRepository OrderRepository => orderRepository.Value;
        public IPersonRepository PersonRepository => personRepository.Value;
        public IBrokerRepository BrokerRepository => brokerRepository.Value;
        #endregion
        #region methods

        public async Task<bool> SaveChangesAsync(bool enableAuditLog = true)
        {
            return await EGIDEntities.SaveChangesAsync(enableAuditLog);
        }
        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(EGIDEntities);
        }
        #endregion
    }
}
