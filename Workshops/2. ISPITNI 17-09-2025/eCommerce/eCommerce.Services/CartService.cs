using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using MapsterMapper;

namespace eCommerce.Services
{
    public class CartService : ICartService
    {
        private readonly eCommerceDbContext _context;
        private readonly IMapper _mapper;

        public CartService(eCommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartResponse> GetCartAsync(int userId)
        {
            var cartResponse = await _context.Carts
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Assets)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cartResponse == null)
            {
                return new CartResponse { Items = new List<CartItemResponse>() };
            }

            return new CartResponse
            {
                Items = cartResponse.CartItems.Select(item => new CartItemResponse
                {
                    Product = _mapper.Map<ProductResponse>(item.Product),
                    Count = item.Quantity
                }).ToList()
            };
        }

        public async Task<CartItemResponse> AddItemAsync(int userId, CartItemInsertRequest request)
        {
            var cart = await GetOrCreateCartAsync(userId);
            
            var existingItem = cart.CartItems
                .FirstOrDefault(ci => ci.ProductId == request.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var newItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    AddedAt = DateTime.UtcNow
                };
                _context.CartItems.Add(newItem);
                existingItem = newItem;
            }

            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            var cartItem = await _context.CartItems
                .Include(ci => ci.Product)
                    .ThenInclude(p => p.Assets)
                .FirstOrDefaultAsync(ci => ci.Id == existingItem.Id);

            return new CartItemResponse
            {
                Product = _mapper.Map<ProductResponse>(cartItem!.Product),
                Count = cartItem.Quantity
            };
        }

        public async Task<CartItemResponse?> UpdateItemAsync(int userId, int itemId, CartItemUpdateRequest request)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var item = await _context.CartItems
                .Include(ci => ci.Product)
                    .ThenInclude(p => p.Assets)
                .FirstOrDefaultAsync(ci => ci.Id == itemId && ci.CartId == cart.Id);

            if (item == null)
                return null;

            item.Quantity = request.Quantity;
            item.UpdatedAt = DateTime.UtcNow;
            cart.UpdatedAt = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();
            return new CartItemResponse
            {
                Product = _mapper.Map<ProductResponse>(item.Product),
                Count = item.Quantity
            };
        }

        public async Task<bool> RemoveItemAsync(int userId, int itemId)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var item = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.Id == itemId && ci.CartId == cart.Id);

            if (item == null)
                return false;

            _context.CartItems.Remove(item);
            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            var cart = await GetOrCreateCartAsync(userId);
            _context.CartItems.RemoveRange(cart.CartItems);
            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<Cart> GetOrCreateCartAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        private CartItemResponse MapItemToResponse(CartItem item)
        {
            return new CartItemResponse
            {
                Product = _mapper.Map<ProductResponse>(item.Product),
                Count = item.Quantity
            };
        }
    }
}

