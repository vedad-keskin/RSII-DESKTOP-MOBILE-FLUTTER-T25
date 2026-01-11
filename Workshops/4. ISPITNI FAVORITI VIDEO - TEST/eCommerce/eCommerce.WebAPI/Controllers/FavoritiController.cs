using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Model.Responses;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Model.Requests;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritiController : ControllerBase
    {
        private readonly IFavoritiService _favoritiService;
        public FavoritiController(IFavoritiService favoritiService)
        {
            _favoritiService = favoritiService;
        }

        [HttpPost("{userId}/{productId}")]
        public async Task<bool> AddFavouritesAsync(int userId, int productId)
        {
            return await _favoritiService.AddFavouritesAsync(userId,productId);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> RemoveFavouritesAsync(int Id)
        {
            return await _favoritiService.RemoveFavouritesAsync(Id);
        }

        [HttpGet]
        public async Task<List<FavoritiResponse>> GetAsync([FromQuery] FavoritiSearchObject? search = null)
        {
            return await _favoritiService.GetAsync(search ?? new FavoritiSearchObject());
        }

     
    }
}
