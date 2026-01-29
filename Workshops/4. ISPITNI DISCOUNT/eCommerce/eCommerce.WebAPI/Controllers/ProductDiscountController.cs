using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDiscountController : BaseCRUDController<ProductDiscountResponse, ProductDiscountSearchObject, ProductDiscountUpsertRequest, ProductDiscountUpsertRequest>
    {
        public ProductDiscountController(IProductDiscountService service) : base(service)
        {
        }
    }
}
