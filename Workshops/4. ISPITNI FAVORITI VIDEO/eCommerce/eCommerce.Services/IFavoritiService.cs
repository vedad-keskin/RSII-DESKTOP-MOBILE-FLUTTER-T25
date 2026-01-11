using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Model.Requests;

namespace eCommerce.Services
{
    public interface IFavoritiService 
    {
        Task<List<FavoritiResponse>> GetAsync(FavoritiSearchObject search);
        Task<bool> AddFavouritesAsync(int userId, int productId);
        Task<bool> RemoveFavouritesAsync(int userId, int productId);
        Task<int> GetUserIdAsync(string username);


    }
}
