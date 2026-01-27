using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public interface IFavouritesService
    {
        Task<List<FavouritesResponse>> GetAsync(FavouritesSearchObject search);
        Task<bool> AddToFavouritesAsync(int userId, int productId);
        Task<bool> RemoveFromFavouritesAsync(int id);
    }
}
