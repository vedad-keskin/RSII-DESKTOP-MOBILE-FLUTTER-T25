using eCommerce.Model.Requests;
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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartResponse>> GetAsync(int userId)
        {
            return await _cartService.GetAsync(userId);
        }

        [HttpGet("{username}/me")]
        public async Task<int> GetUserIdAsync(string username)
        {
            return await _cartService.GetUserIdAsync(username);
        }

        [HttpPost("{userId}/{productId}")]
        public async Task<ActionResult<bool>> AddItemAsync(int userId, int productId)
        {
            return await _cartService.AddItemAsync(userId, productId);
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<ActionResult<bool>> RemoveItemAsync(int userId, int productId)
        {
            return await _cartService.RemoveItemAsync(userId, productId);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> ClearCartAsync(int userId)
        {
            return await _cartService.ClearCartAsync(userId);
        }

        [HttpPost("{userId}/checkout")]
        public async Task<ActionResult<bool>> CheckoutAsync(int userId)
        {
            return await _cartService.CheckoutAsync(userId);
        }
    }
} 