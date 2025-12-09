using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public interface ICartService
    {
        Task<CartResponse> GetCartAsync(int userId);
        Task<CartItemResponse> AddItemAsync(int userId, CartItemInsertRequest request);
        Task<CartItemResponse?> UpdateItemAsync(int userId, int itemId, CartItemUpdateRequest request);
        Task<bool> RemoveItemAsync(int userId, int itemId);
        Task<bool> ClearCartAsync(int userId);
    }
}

