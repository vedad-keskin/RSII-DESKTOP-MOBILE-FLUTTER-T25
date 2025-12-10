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