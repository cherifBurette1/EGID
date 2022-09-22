using EGID.Data.Entities;
using EGID.DTO.Models;
using EGID.Service.Features.Stocks.Interfaces.Factories;
using System;

namespace EGID.Presistance.Features.Stocks.Implementation.Factories
{
    public class StockFactory : IStockFactory
    {
        public DTOStock CreateStockDTO(Stock stock)
        {
            return new DTOStock()
            {
                Id = stock.Id,
                Name = stock.Name,
                Price = stock.Price
            };
        }

    }
}
