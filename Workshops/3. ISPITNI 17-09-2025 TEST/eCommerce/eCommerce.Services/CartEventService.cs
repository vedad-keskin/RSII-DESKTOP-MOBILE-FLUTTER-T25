using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class CartEventService : ICartEventService
    {
        private readonly eCommerceDbContext _context;

        public CartEventService(eCommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartEventResponse>> GetAsync(CartEventSearchObject search)
        {
            var query = _context.CartEventsIB180079
                .Include(x => x.User)
                .Include(x => x.Product)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.UserFullName))
            {
                query = query.Where(x => 
                    (x.User.FirstName + " " + x.User.LastName).Contains(search.UserFullName));
            }

            if (!string.IsNullOrEmpty(search.ProductName))
            {
                query = query.Where(x => x.Product != null && x.Product.Name.Contains(search.ProductName));
            }

            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(x => 
                    (x.User.FirstName + " " + x.User.LastName).Contains(search.FTS) ||
                    (x.Product != null && x.Product.Name.Contains(search.FTS)) ||
                    x.Type.Contains(search.FTS));
            }

            var events = await query.OrderByDescending(x => x.CreatedAt).ToListAsync();

            return events.Select(x => new CartEventResponse
            {
                FullName = $"{x.User.FirstName} {x.User.LastName}",
                ProductName = x.Product?.Name ?? string.Empty,
                Type = x.Type,
                CreatedAt = x.CreatedAt
            }).ToList();
        }
    }
}

