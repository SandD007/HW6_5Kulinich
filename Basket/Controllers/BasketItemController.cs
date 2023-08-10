using Basket.Models.Requests;
using Basket.Models.Response;
using Basket.Repositories.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("basket.basketitem")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketItemController : ControllerBase
    {
        private readonly ILogger<BasketItemController> _logger;
        private readonly IBasketItemRepository _basketItemRepository;

        public BasketItemController(
        ILogger<BasketItemController> logger,
        IBasketItemRepository basketItemRepository)
        {
            _logger = logger;
            _basketItemRepository = basketItemRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var result = await _basketItemRepository.Add(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }
    }
}
