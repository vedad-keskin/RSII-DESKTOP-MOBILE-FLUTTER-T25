using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Responses;
using eCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Model.Requests;
using MapsterMapper;
using eCommerce.Services.ProductStateMachine;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
namespace eCommerce.Services
{
    public class FavoritiService : IFavoritiService
    {
        private readonly eCommerceDbContext _context;

        public FavoritiService(eCommerceDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> AddFavouritesAsync(int userId, int productId)
        {

            var exists = await _context.FavoritiIB180079.AnyAsync(x => x.UserId == userId && x.ProductId == productId);

            if (exists)
            {
                return false;
            }

            var newFavorite = new FavoritiIB180079()
            {
                UserId = userId,
                ProductId = productId
            };

            _context.FavoritiIB180079.Add(newFavorite);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<FavoritiResponse>> GetAsync(FavoritiSearchObject search)
        {

            var query = _context.FavoritiIB180079
                .Include(x => x.Product)
                .Include(x => x.User)
                .AsQueryable();

            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt >=  search.DateFrom.Value);
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.CreatedAt <= search.DateTo.Value);
            }
            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var favorites = await query.ToListAsync();
            return favorites.Select(MapToResponse).ToList();

        }

        private FavoritiResponse MapToResponse(FavoritiIB180079 favorit)
        {

            return new FavoritiResponse
            {
                Id = favorit.Id,
                CreatedAt = favorit.CreatedAt,
                UserFullName = $"{favorit.User.FirstName} {favorit.User.LastName}",
                ProductName = favorit.Product.Name,
                ProductId = favorit.ProductId,
                UserId = favorit.UserId
            };

        }

        public async Task<bool> RemoveFavouritesAsync(int userId, int productId)
        {

            var favourite = await _context.FavoritiIB180079.Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefaultAsync();
            
            if(favourite == null)
            {
                return false;
            }

            _context.FavoritiIB180079.Remove(favourite);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<int> GetUserIdAsync(string username)
        {

            var loggedInUser = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();

            if(loggedInUser == null)
            {

                return 2;

            }

            return loggedInUser.Id;


        }

        //protected override IQueryable<Database.Product> ApplyFilter(IQueryable<Database.Product> query, ProductSearchObject search)
        //{
        //    if (!string.IsNullOrEmpty(search.FTS))
        //    {
        //        query = query.Where(p => p.Name.Contains(search.FTS) || p.Description.Contains(search.FTS));
        //    }

            if (loggedInUser == null)
            {
                //throw new KeyNotFoundException("User not found.");
                return 2;
            }


            //return loggedInUser?.Id ?? 2;
            return loggedInUser.Id;

        }


    }
    }
