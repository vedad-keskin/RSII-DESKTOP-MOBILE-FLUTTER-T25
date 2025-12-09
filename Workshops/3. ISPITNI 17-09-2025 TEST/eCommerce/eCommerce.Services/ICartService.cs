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
        //Task<UserResponse> CreateAsync(UserUpsertRequest request);
        //Task<UserResponse?> UpdateAsync(int id, UserUpsertRequest request);
        //Task<bool> DeleteAsync(int id);
        //Task<UserResponse?> AuthenticateAsync(UserLoginRequest request);
    }
} 