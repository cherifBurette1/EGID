using EGID.Service.Feature.Stocks.Interfaces.Services;
using EGID.Service.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Common.Interfaces.Helpers;
using EGID.Service.Features.Stocks.Interfaces.Factories;
using EGID.DTO.Models;
using EGID.Service.Feature.Stocks.Interfaces.Validators;
using System.Collections.Generic;

namespace Qorrect.Service.Feature.Stocks.Implementation.Services
{
    public class StocksService : IStocksService
    {
        private readonly Lazy<IStockFactory> _StockFactory;
        private readonly Lazy<IStockValidator> _stockValidator;
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IBackgroundSchedular> _backgroundSchedular;
        private readonly Lazy<IHttpClientFactory> _clientFactory;
        public StocksService(Lazy<IStockFactory> StockFactory,
            Lazy<IStockValidator> stockValidator,
            Lazy<IUnitOfWork> unitOfWork,
            Lazy<IBackgroundSchedular> backgroundSchedular,
            Lazy<IHttpClientFactory> clientFactory)
        {
            _stockValidator = stockValidator;
            _StockFactory = StockFactory;
            _unitOfWork = unitOfWork;
            _backgroundSchedular = backgroundSchedular;
            _clientFactory = clientFactory;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IStockFactory StockFactory => _StockFactory.Value;
        private IBackgroundSchedular BackgroundSchedular => _backgroundSchedular.Value;
        private IHttpClientFactory ClientFactory => _clientFactory.Value;
        private IStockValidator StockValidator => _stockValidator.Value;

        public async Task<ServiceResultDetail<DTOStock>> GetCertainStock(int stockId)
        {
            var stockValidation = await StockValidator.IsStockIdAvailable(stockId);
            if (!stockValidation.IsValid)
            {
                return new ServiceResultDetail<DTOStock>()
                {
                    IsValid = false,
                    Errors = new List<string>() { stockValidation.Message }
                };
            }
            var stock = await UnitOfWork.StockRepository.GetCertainStock(stockId);
            var dto = StockFactory.CreateStockDTO(stock);
            return new ServiceResultDetail<DTOStock>()
            {
                Model = dto,
                IsValid = true
            };
        }

        public async Task<ServiceResultList<DTOStock>> GetStocks()
        {
            var data = await UnitOfWork.StockRepository.GetStocks();
            var dtos = data.Select(x => StockFactory.CreateStockDTO(x)).ToList();
            return new ServiceResultList<DTOStock>()
            {
                Model = dtos,
                IsValid = true
            };
        }
        public async Task<ServiceResultList<DTOStock>> UpdateAndGetStocks()
        {
            var rand = new Random();
            var data = await UnitOfWork.StockRepository.GetStocks();
            foreach (var item in data)
            {
                item.Price = rand.Next(1, 100);
            }
            var result = await UnitOfWork.SaveChangesAsync();
            if (result)
            {
                var dtos = data.Select(x => StockFactory.CreateStockDTO(x)).ToList();
                return new ServiceResultList<DTOStock>()
                {
                    Model = dtos,
                    IsValid = true
                };
            }
            else return null;
        }
    } 
}