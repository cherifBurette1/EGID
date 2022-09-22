using EGID.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Service.Features.Orders.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task Create(Data.Entities.Order order);
        Task<int> GetLastIdOrder();
        Task<List<Order>> GetOrderList();
        Task<bool> IsThereAnyOrder();
    }
}
