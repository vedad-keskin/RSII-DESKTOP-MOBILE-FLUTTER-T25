using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

            if(exisitingProduct != null) // ako povecavamo quantity
            {

                exisitingProduct.Quantity += 1;
                exisitingProduct.UpdatedAt = DateTime.Now;


                await _context.SaveChangesAsync();



                var noviCartEvent = new CartEventIB180079()
                {
                    CartId = cart.Id,
                    CartItemId = exisitingProduct.Id,
                    UserId = userId,
                    ProductId = productId,
                    Type = "Quantity Change",
                    OldQuantity = exisitingProduct.Quantity - 1,
                    NewQuantity = exisitingProduct.Quantity

                };

                _context.CartEventIB180079.Add(noviCartEvent);
                await _context.SaveChangesAsync();




            }
            else // dodavanje proizvoda
            {

                var noviCartItem = new CartItem
                {

                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = 1,
                    AddedAt = DateTime.Now,

                };

                _context.CartItems.Add(noviCartItem);
                await _context.SaveChangesAsync();


                var noviCartEvent = new CartEventIB180079()
                {
                    CartId = cart.Id,
                    CartItemId = noviCartItem.Id,
                    UserId = userId,
                    ProductId = productId,
                    Type = "Adding",
                    OldQuantity = 0,
                    NewQuantity = 1

                };

                _context.CartEventIB180079.Add(noviCartEvent);
                await _context.SaveChangesAsync();

            }



            return true;

        }


        public async Task<bool> RemoveItemAsync(int userId, int productId)
        {
            var cart = await _context.Carts
                 .Include(x => x.CartItems)
                 .Where(x => x.UserId == userId)
                 .FirstOrDefaultAsync();

            if (cart == null)
            {
                //throw new KeyNotFoundException("Cart not found.");
                return false;
            }

            var exisitingProduct = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

            if (exisitingProduct != null)
            {

                var noviCartEvent = new CartEventIB180079()
                {
                    CartId = null,
                    CartItemId = null,
                    UserId = userId,
                    ProductId = productId,
                    Type = "Removing",
                    OldQuantity = exisitingProduct.Quantity,
                    NewQuantity = 0

                };

                _context.CartEventIB180079.Add(noviCartEvent);
                await _context.SaveChangesAsync();




                _context.CartItems.Remove(exisitingProduct);
                await _context.SaveChangesAsync();
            }
            else
            {
                //throw new KeyNotFoundException("Cart Item not found.");
                return false;
            }


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
                //throw new KeyNotFoundException("Cart not found.");
                return new CartResponse();
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
                //throw new KeyNotFoundException("User not found.");
                return 2;
            }


            //return loggedInUser?.Id ?? 2;
            return loggedInUser.Id;

        }

        public async Task<bool> ClearCartAysnc(int userId)
        {
            var cart = await _context.Carts
                    .Include(x => x.CartItems)
                    .Where(x => x.UserId == userId)
                    .FirstOrDefaultAsync();

            if (cart == null)
            {
                //throw new KeyNotFoundException("Cart not found.");
                return false;
            }
            else
            {

                var tempCartItems = _context.CartItems.Where(x => x.CartId == cart.Id).ToList();

                for (int i = 0; i < tempCartItems.Count(); i++)
                {

                    var noviCartEvent = new CartEventIB180079()
                    {
                        CartId = null,
                        CartItemId = null,
                        UserId = userId,
                        ProductId = tempCartItems[i].ProductId,
                        Type = "Clear Cart",
                        OldQuantity = tempCartItems[i].Quantity,
                        NewQuantity = 0

                    };

                    _context.CartEventIB180079.Add(noviCartEvent);
                    await _context.SaveChangesAsync();


                }




                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();

            }

            return true;

        }

        public async Task<bool> CheckoutAysnc(int userId)
        {
            var cart = await _context.Carts
           .Include(x => x.CartItems)
           .Where(x => x.UserId == userId)
           .FirstOrDefaultAsync();

            if (cart == null)
            {
                //throw new KeyNotFoundException("Cart not found.");
                return false;
            }
            else
            {

                var tempCartItems = _context.CartItems.Where(x => x.CartId == cart.Id).ToList();

                for (int i = 0; i < tempCartItems.Count(); i++)
                {

                    var noviCartEvent = new CartEventIB180079()
                    {
                        CartId = null,
                        CartItemId = null,
                        UserId = userId,
                        ProductId = tempCartItems[i].ProductId,
                        Type = "Checkout",
                        OldQuantity = tempCartItems[i].Quantity,
                        NewQuantity = 0

                    };

                    _context.CartEventIB180079.Add(noviCartEvent);
                    await _context.SaveChangesAsync();


                }




                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();

            }

            return true;
        }
    }
} 