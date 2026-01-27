using eCommerce.Services.Database;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class FavouritesService : IFavouritesService
    {
        private readonly eCommerceDbContext _context;

        public FavouritesService(eCommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavouritesResponse>> GetAsync(FavouritesSearchObject search)
        {
            var query = _context.Favourites.AsQueryable();

            if (search.DateFrom.HasValue)
            {
                query = query.Where(f => f.CreatedAt >= search.DateFrom.Value);
            }

            if (search.DateTo.HasValue)
            {
                query = query.Where(f => f.CreatedAt <= search.DateTo.Value);
            }

            if (search.UserId.HasValue)
            {
                query = query.Where(f => f.UserId == search.UserId.Value);
            }

            if (search.ProductId.HasValue)
            {
                query = query.Where(f => f.ProductId == search.ProductId.Value);
            }

            var favourites = await query.ToListAsync();
            return favourites.Select(MapToResponse).ToList();
        }

        public async Task<bool> AddToFavouritesAsync(int userId, int productId)
        {
            var exists = await _context.Favourites
                .AnyAsync(f => f.UserId == userId && f.ProductId == productId);
            
            if (exists)
                return false;

            var favourite = new Favourites
            {
                UserId = userId,
                ProductId = productId
            };

            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromFavouritesAsync(int id)
        {
            var favourite = await _context.Favourites.FindAsync(id);
            if (favourite == null)
                return false;

            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();
            return true;
        }

        private FavouritesResponse MapToResponse(Favourites favourite)
        {
            return new FavouritesResponse
            {
                Id = favourite.Id,
                UserId = favourite.UserId,
                ProductId = favourite.ProductId,
                CreatedAt = favourite.CreatedAt
            };
        }
    }
}
