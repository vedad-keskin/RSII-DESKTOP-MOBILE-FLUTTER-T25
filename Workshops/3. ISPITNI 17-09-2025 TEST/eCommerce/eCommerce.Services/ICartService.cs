using eCommerce.Services.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Model.Responses;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;

namespace eCommerce.Services
{
    public interface ICartService
    {
        Task<CartResponse> GetAsync(int userId);
        Task<int> GetUserIdAsync (string username);
        Task<bool> AddItemAsync(int userId, int productId);
        Task<bool> RemoveItemAsync(int userId, int productId);
    }
} 