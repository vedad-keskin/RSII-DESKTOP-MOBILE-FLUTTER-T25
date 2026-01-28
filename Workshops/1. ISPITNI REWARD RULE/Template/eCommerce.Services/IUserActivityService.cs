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
    public interface IUserActivityService : ICRUDService<UserActivityResponse, UserActivitySearchObject, UserActivityUpsertRequest, UserActivityUpsertRequest>
    {
        Task<UserActivityResponse> ChangeStatusAsync(int id, string status);

    }
}
