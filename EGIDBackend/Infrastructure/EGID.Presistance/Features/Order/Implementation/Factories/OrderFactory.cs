using EGID.DTO.Models;
using EGID.Service.Features.Orders.Interfaces.Factories;
using EGID.Service.Features.Orders.Interfaces.Helpers;
using System;

namespace EGID.Presistance.Features.Order.Implementation.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly Lazy<IOrdersHelper> _orderHelper;
        public OrderFactory(Lazy<IOrdersHelper> orderHelper)
        {
            _orderHelper = orderHelper;
        }
        private IOrdersHelper OrderHelper => _orderHelper.Value;
        public Data.Entities.Order CreateOrderDTO(DTOOrder order, int lastId)
        {
            var rand = new Random();
            return new Data.Entities.Order()
            {
                Id = lastId+1,
                BrokerId = order.BrokerId,
                PersonId = order.PersonId.HasValue && !(order.PersonId.Value == 0)? order.PersonId : null,
                Price = order.Price,
                Commission = OrderHelper.CalculateCommission(order.Price, order.PersonId.HasValue),
                Quantity = (int)(order.Price * rand.Next(1,10)),
                StockId = order.Id
            };
        }
        public DTOOrderList CreateOrderListItemDTO(Data.Entities.Order order)
        {
            return new DTOOrderList()
            {
                Id = order.Id,
                BrokerName = order.Broker.Name,
                PersonName = order.Person?.Name,
                Price = order.Price,
                Commission = OrderHelper.CalculateCommission(order.Price, order.PersonId.HasValue),
                StockName = order.Stock.Name,
                Quantity = order.Quantity
            };
        }

    }
}
