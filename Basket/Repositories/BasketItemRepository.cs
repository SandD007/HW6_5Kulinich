using Basket.Data.Entities;
using Basket.Models.Requests;
using Basket.Models.Response;
using Basket.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime;

namespace Basket.Repositories
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly ILogger<BasketItemRepository> _logger;
        private readonly IInternalHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public BasketItemRepository(
            ILogger<BasketItemRepository> logger,
            IInternalHttpClientService httpClient,
            IOptions<AppSettings> settings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            var response = await _httpClient.SendAsync<AddItemResponse<int>, CreateProductRequest>("http://www.alevelwebsite.com:5000/api/v1/catalogItem/Add",
            HttpMethod.Post,
            new CreateProductRequest()
            {
                Name = name,
                Description = description,
                Price = price,
                AvailableStock = availableStock,
                CatalogBrandId = catalogBrandId,
                CatalogTypeId = catalogTypeId,
                PictureFileName = pictureFileName
            });

            return response.Id;
        }
    }
}
