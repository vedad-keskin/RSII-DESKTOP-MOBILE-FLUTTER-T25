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

        public async Task<bool> AddItemAsync(int userId, int productId)
        {

            var cart = await _context.Carts
                .Include(x => x.CartItems)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();


            // ako korisnik prvi put dodaje produkt bez da ima cart kreiran

            if(cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                };

                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();

            }

            cart.UpdatedAt = DateTime.Now;

            var exisitingProduct = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

            if(exisitingProduct != null)
            {

                exisitingProduct.Quantity += 1;
                exisitingProduct.UpdatedAt = DateTime.Now;

            }
            else
            {

                cart.CartItems.Add(new CartItem
                {

                    ProductId = productId,
                    Quantity = 1,
                    AddedAt = DateTime.Now,

                });
            }

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<CartResponse> GetAsync(int userId)
        {

            var cartResponse = await _context.Carts
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Assets)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cartResponse == null)
            {
                throw new KeyNotFoundException("Cart not found.");
            }


            return new CartResponse
            {

                Id = cartResponse!.Id,
                UserId = cartResponse.UserId,
                Items = cartResponse.CartItems
                .Select(item => new CartItemResponse
                {
                    Product = _mapper.Map<ProductResponse>(item.Product),
                    Count = item.Quantity
                }).ToList()



            };


        }

        public async Task<int> GetUserIdAsync(string username)
        {

            var loggedInUser = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();

            if (loggedInUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }


            //return loggedInUser?.Id ?? 2;
            return loggedInUser.Id;

        }
    }
} 