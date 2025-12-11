using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

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

        public async Task<CartResponse> GetAsync(int userId)
        {
            
            var cartResponse = await _context.Carts
                .Include(x=> x.CartItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Assets)
                .Where(x=> x.UserId == userId)
                .FirstOrDefaultAsync();

            if(cartResponse != null)
            {

                return new CartResponse
                {
                    Id = cartResponse!.Id,
                    UserId = cartResponse.UserId,
                    Items = cartResponse!.CartItems
                    .Select(item => new CartItemResponse
                    {
                        Product = _mapper.Map<ProductResponse>(item.Product),
                        Count = item.Quantity
                    }).ToList()
                };

            }else
            {
                return new CartResponse();
            }


        }

        public async Task<int> GetUserIdAsync(string username)
        {
            var loggedInUser = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();


            return loggedInUser?.Id ?? 2;

        }

        public async Task<bool> AddItemAsync(int userId, int productId)
        {
            var cart = await _context.Carts
                .Include(x => x.CartItems)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
            {
                var oldQuantity = existingItem.Quantity;
                existingItem.Quantity += 1;
                existingItem.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                // Create quantity change event
                _context.CartEventsIB180079.Add(new CartEventIB180079
                {
                    CartId = cart.Id,
                    CartItemId = existingItem.Id,
                    UserId = userId,
                    ProductId = productId,
                    Type = "Quantity Change",
                    OldQuantity = oldQuantity,
                    NewQuantity = existingItem.Quantity
                });
            }
            else
            {
                var newItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1,
                };
                cart.CartItems.Add(newItem);
                await _context.SaveChangesAsync();

                // Create adding event
                _context.CartEventsIB180079.Add(new CartEventIB180079
                {
                    CartId = cart.Id,
                    CartItemId = newItem.Id,
                    UserId = userId,
                    ProductId = productId,
                    Type = "Adding",
                    OldQuantity = null,
                    NewQuantity = 1
                });
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveItemAsync(int userId, int productId)
        {
            var cart = await _context.Carts
                .Include(x => x.CartItems)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart == null){
                return false;
            }

            var item = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                var cartItemId = item.Id;
                
                // Create removing event
                var cartEvent = new CartEventIB180079
                {
                    CartId = cart.Id,
                    CartItemId = cartItemId,
                    UserId = userId,
                    ProductId = productId,
                    Type = "Removing",
                    OldQuantity = item.Quantity,
                    NewQuantity = null
                };
                _context.CartEventsIB180079.Add(cartEvent);
                await _context.SaveChangesAsync();

                // Set CartItemId to null to allow deletion
                cartEvent.CartItemId = null;

                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }else{
                return false;
            }

            return true;
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(x => x.CartItems)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart != null)
            {
                var cartId = cart.Id;
                var cartItemIds = cart.CartItems.Select(x => x.Id).ToList();
                var events = new List<CartEventIB180079>();

                // Create clearing event for each item
                foreach (var item in cart.CartItems)
                {
                    var cartEvent = new CartEventIB180079
                    {
                        CartId = cartId,
                        CartItemId = item.Id,
                        UserId = userId,
                        ProductId = item.ProductId,
                        Type = "Clearing",
                        OldQuantity = item.Quantity,
                        NewQuantity = null
                    };
                    events.Add(cartEvent);
                    _context.CartEventsIB180079.Add(cartEvent);
                }

                await _context.SaveChangesAsync();

                // Set CartItemId and CartId to null to allow deletion
                foreach (var evt in events)
                {
                    evt.CartItemId = null;
                    evt.CartId = null;
                }

                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> CheckoutAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(x => x.CartItems)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart != null)
            {
                var cartId = cart.Id;
                var events = new List<CartEventIB180079>();

                // Create checkout event for each item
                foreach (var item in cart.CartItems)
                {
                    var cartEvent = new CartEventIB180079
                    {
                        CartId = cartId,
                        CartItemId = item.Id,
                        UserId = userId,
                        ProductId = item.ProductId,
                        Type = "Checkout",
                        OldQuantity = item.Quantity,
                        NewQuantity = null
                    };
                    events.Add(cartEvent);
                    _context.CartEventsIB180079.Add(cartEvent);
                }

                await _context.SaveChangesAsync();

                // Set CartItemId and CartId to null to allow deletion
                foreach (var evt in events)
                {
                    evt.CartItemId = null;
                    evt.CartId = null;
                }

                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
} 