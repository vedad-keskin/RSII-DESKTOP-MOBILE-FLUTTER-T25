using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.WebAPI.Controllers
{
    // [Authorize(Roles = "Administrator")]
    [AllowAnonymous]
    public class UserActivityController : BaseCRUDController<UserActivityResponse, UserActivitySearchObject, UserActivityUpsertRequest, UserActivityUpsertRequest>
    {
        IUserActivityService _userActivityService;
        public UserActivityController(IUserActivityService service) : base(service)
        {
            _userActivityService = service;
        }


        [HttpPost("change-status")]
        public async Task<ActionResult<UserActivityResponse>> ChangeStatusAsync(int id, string status)
        {

            var result = await _userActivityService.ChangeStatusAsync(id, status);

            return Ok(result);
        }


    }
} 