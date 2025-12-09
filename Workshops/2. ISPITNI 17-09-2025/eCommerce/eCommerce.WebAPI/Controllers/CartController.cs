using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                throw new UnauthorizedAccessException("User not authenticated");
            return userId;
        }

        [HttpGet]
        public async Task<CartResponse> GetCart()
        {
            var userId = GetCurrentUserId();
            return await _cartService.GetCartAsync(userId);
        }

        [HttpPost("items")]
        public async Task<CartItemResponse> AddItem([FromBody] CartItemInsertRequest request)
        {
            var userId = GetCurrentUserId();
            return await _cartService.AddItemAsync(userId, request);
        }

        [HttpPut("items/{itemId}")]
        public async Task<CartItemResponse?> UpdateItem(int itemId, [FromBody] CartItemUpdateRequest request)
        {
            var userId = GetCurrentUserId();
            return await _cartService.UpdateItemAsync(userId, itemId, request);
        }

        [HttpDelete("items/{itemId}")]
        public async Task<bool> RemoveItem(int itemId)
        {
            var userId = GetCurrentUserId();
            return await _cartService.RemoveItemAsync(userId, itemId);
        }

        [HttpDelete]
        public async Task<bool> ClearCart()
        {
            var userId = GetCurrentUserId();
            return await _cartService.ClearCartAsync(userId);
        }
    }
}

