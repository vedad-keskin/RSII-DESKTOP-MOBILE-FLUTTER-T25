using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;

namespace eCommerce.Services
{
    public interface ICartEventService
    {
        Task<List<CartEventResponse>> GetAsync(CartEventSearchObject search);
    }
}

