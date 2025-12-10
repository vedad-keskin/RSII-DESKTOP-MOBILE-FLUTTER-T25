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
        Task<int> GetUserIdAsync(string username);
        Task<bool> AddItemAsync(int userId, int productId);


        //Task<UserResponse?> GetByIdAsync(int id);
        //Task<UserResponse> CreateAsync(UserUpsertRequest request);
        //Task<UserResponse?> UpdateAsync(int id, UserUpsertRequest request);
        //Task<UserResponse?> AuthenticateAsync(UserLoginRequest request);
    }
} 