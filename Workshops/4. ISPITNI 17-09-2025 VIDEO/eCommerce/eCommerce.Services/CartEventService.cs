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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eCommerce.Services
{
    public class CartEventService : ICartEventService
    {
        private readonly eCommerceDbContext _context;
        private readonly IMapper _mapper;

        public CartEventService(eCommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CartEventResponse>> GetAsync(CartEventSearchObject search)
        {
            var query = _context.CartEventIB180079
                .Include(x => x.User)
                .Include(x => x.Product)
                .AsQueryable();


            if (!string.IsNullOrEmpty(search.FullName))
            {
                query = query.Where(x => (x.User!.FirstName + " " + x.User!.LastName).Contains(search.FullName)  );
            }

            if (!string.IsNullOrEmpty(search.ProductName))
            {
                query = query.Where(u => u.Product!.Name.Contains(search.ProductName));
            }

            var cartEvents = await query.ToListAsync();

            return cartEvents.Select(x => new CartEventResponse
            {
                FullName = $"{x.User?.FirstName ?? string.Empty} {x.User?.LastName ?? string.Empty}",
                ProductName = x.Product?.Name ?? string.Empty,
                Type = x.Type,
                CreatedAt = x.CreatedAt,

            }).ToList();

        }


    }
} 