using Microsoft.AspNetCore.Mvc;
using EGID.DTO.Models;
using System;
using System.Threading.Tasks;
using EGID.Service.Feature.Orders.Interfaces.Services;

namespace EGID.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly Lazy<IOrderService> _orderService;
        /// <summary>
        /// Academic-Level Constructor
        /// </summary>
        /// <param name="orderService"></param>
        public OrderController(Lazy<IOrderService> orderService)
        {
            _orderService = orderService;
        }
        private IOrderService OrderService => _orderService.Value;
        /// <summary>
        /// save order
        /// </summary>
        /// <returns>successs</returns>
        [HttpPost("order", Name = "SaveOrder")]
        public async Task<IActionResult> GetsOrder(DTOOrder order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await OrderService.CreateOrder(order);
            return GetApiResponse(result);
        }
        /// <summary>
        /// gets list of order
        /// </summary>
        /// <returns>list of order</returns>
        [HttpGet("orders", Name = "GetOrder")]
        public async Task<IActionResult> GetOrders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await OrderService.GetOrders();
            return GetApiResponse(result);
        }
    }
}