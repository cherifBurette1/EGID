using EGID.Service.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Common.Interfaces.Helpers;
using EGID.DTO.Models;
using EGID.Service.Features.Orders.Interfaces.Factories;
using EGID.Service.Feature.Orders.Interfaces.Services;

namespace Qorrect.Service.Feature.Order.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly Lazy<IOrderFactory> _OrderFactory;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        public OrderService(Lazy<IOrderFactory> OrderFactory,
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IBackgroundSchedular> backgroundSchedular,
            Lazy<IHttpClientFactory> clientFactory)
        {
            _OrderFactory = OrderFactory;
            _unitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IOrderFactory OrderFactory => _OrderFactory.Value;

        public async Task<ServiceResultDetail<string>> CreateOrder(DTOOrder model)
        {
            EGID.Data.Entities.Order orderDto;
            var isThereAnyOrder = await UnitOfWork.OrderRepository.IsThereAnyOrder();
            if (isThereAnyOrder)
            {
                var lastId = await UnitOfWork.OrderRepository.GetLastIdOrder();
                 orderDto =OrderFactory.CreateOrderDTO(model, lastId);
            }
            else
            {
                 orderDto = OrderFactory.CreateOrderDTO(model, 0);
            }
            await UnitOfWork.OrderRepository.Create(orderDto);
            await UnitOfWork.SaveChangesAsync();

            return new ServiceResultDetail<string>()
            {
                IsValid = true,
                Model = "added successfully"
            };
        }

        public async Task<ServiceResultList<DTOOrderList>> GetOrders()
        {
            var data = await UnitOfWork.OrderRepository.GetOrderList();
            var dtos = data.Select(x => OrderFactory.CreateOrderListItemDTO(x)).ToList();
            return new ServiceResultList<DTOOrderList>()
            {
                Model = dtos,
                IsValid = true
            };
        }
    }
}