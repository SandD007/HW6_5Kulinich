using Infrastructure.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Basket.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Basket.Repositories;
using System.Net;
using Basket.Models.Response;

namespace Basket.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketBffController : ControllerBase
    {
        private readonly ILogger<BasketBffController> _logger;

        public BasketBffController(
        ILogger<BasketBffController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetSomeText()
        {
            var response = new AddItemResponse<string>
            {
                Id = "U Anonymous"
            };
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetUserText()
        {
            var user = User.FindFirstValue("sub");
            var response = new AddItemResponse<string>
            {
                Id = $"U {user}"
            };
            return Ok(response);
        }
    }
}
