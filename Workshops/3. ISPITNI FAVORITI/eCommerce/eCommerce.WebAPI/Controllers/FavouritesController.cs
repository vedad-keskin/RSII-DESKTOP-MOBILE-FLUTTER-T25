using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouritesService _favouritesService;

        public FavouritesController(IFavouritesService favouritesService)
        {
            _favouritesService = favouritesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FavouritesResponse>>> Get([FromQuery] FavouritesSearchObject? search = null)
        {
            return await _favouritesService.GetAsync(search ?? new FavouritesSearchObject());
        }

        [HttpPost]
        public async Task<ActionResult> AddToFavourites([FromQuery] int userId, [FromQuery] int productId)
        {
            var result = await _favouritesService.AddToFavouritesAsync(userId, productId);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFromFavourites(int id)
        {
            var result = await _favouritesService.RemoveFromFavouritesAsync(id);
            return result ? Ok() : NotFound();
        }
    }
}
