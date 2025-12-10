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
                existingItem.Quantity += 1;
                existingItem.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = 1,
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
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
} 