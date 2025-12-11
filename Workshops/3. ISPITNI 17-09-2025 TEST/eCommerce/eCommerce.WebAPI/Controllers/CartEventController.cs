using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartEventController : ControllerBase
    {
        private readonly ICartEventService _cartEventService;

        public CartEventController(ICartEventService cartEventService)
        {
            _cartEventService = cartEventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartEventResponse>>> Get([FromQuery] CartEventSearchObject? search = null)
        {
            return await _cartEventService.GetAsync(search ?? new CartEventSearchObject());
        }
    }
}

