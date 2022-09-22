using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Orders.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EGID.Presistance.Features.Order.Implementation.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IEGIDEntities _EGIDEntities;
        public OrderRepository(IEGIDEntities eGIDEntities)
        {
            _EGIDEntities = eGIDEntities;
        }

        public async Task<List<Data.Entities.Order>> GetOrderList()
        {
            return await _EGIDEntities.Orders.Include(a => a.Stock).Include(a => a.Broker).Include(a => a.Person).ToListAsync();
        }
        public async Task<int> GetLastIdOrder()
        {
            return await _EGIDEntities.Orders.CountAsync();
        }
        public async Task<bool> IsThereAnyOrder()
        {
            return await _EGIDEntities.Orders.AnyAsync();
        }
        public async Task Create(Data.Entities.Order order)
        {
            await _EGIDEntities.Set<Data.Entities.Order>().AddAsync(order);
        }
    }
}
