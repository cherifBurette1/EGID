using EGID.Service.Models;
using System.Threading.Tasks;
using EGID.DTO.Models;

namespace EGID.Service.Feature.Orders.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<ServiceResultList<DTOOrderList>> GetOrders();
        public Task<ServiceResultDetail<string>> CreateOrder(DTOOrder model);
    }
}