using EGID.DTO.Models;

namespace EGID.Service.Features.Orders.Interfaces.Factories
{
    public interface IOrderFactory
    {
        public Data.Entities.Order CreateOrderDTO(DTOOrder order, int lastId);
        public DTOOrderList CreateOrderListItemDTO(Data.Entities.Order order);
    }
}
