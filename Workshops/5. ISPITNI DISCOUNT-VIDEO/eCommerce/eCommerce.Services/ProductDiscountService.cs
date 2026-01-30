using eCommerce.Model.Requests;
using eCommerce.Model.Responses;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class ProductDiscountService : BaseCRUDService<ProductDiscountResponse, ProductDiscountSearchObject, Database.ProductDiscount, ProductDiscountUpsertRequest, ProductDiscountUpsertRequest>, IProductDiscountService
    {
        public ProductDiscountService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Database.ProductDiscount> ApplyFilter(IQueryable<Database.ProductDiscount> query, ProductDiscountSearchObject search)
        {

            query = query.Include(r => r.Product.Assets);


            if (!string.IsNullOrEmpty(search.ProductName))
            {
                query = query.Where(r => r.Product.Name.Contains(search.ProductName));
            }



            return query;
        }

        protected override ProductDiscountResponse MapToResponse(ProductDiscount entity)
        {

            var response = new ProductDiscountResponse
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                ProductName = entity?.Product?.Name ?? string.Empty,
                ProductPrice = entity?.Product?.Price ?? 0,
                Discount = entity?.Discount ?? 0,
                DateFrom = entity?.DateFrom ?? DateTime.Now,
                DateTo = entity?.DateTo ?? DateTime.Now,
                NewPrice = entity.Product.Price * (1 - entity.Discount / 100 )
                
            };

            if(entity?.Product?.Assets != null)
            {

                response.Assets = entity.Product.Assets.Select(asset => new AssetResponse
                {

                    Id = asset.Id,
                    Name = asset.FileName,
                    Description = asset.ContentType,
                    Base64Content = asset.Base64Content,
                    IsActive = true,
                    CreatedAt = asset.CreatedAt,
                    UpdatedAt = null


                }).ToList();



            }



            return response;
        }



        //protected override async Task BeforeInsert(Database.Role entity, RoleUpsertRequest request)
        //{
        //    // Check for duplicate role name
        //    if (await _context.Roles.AnyAsync(r => r.Name == request.Name))
        //    {
        //        throw new InvalidOperationException("A role with this name already exists.");
        //    }
        //}

        //protected override async Task BeforeUpdate(Database.Role entity, RoleUpsertRequest request)
        //{
        //    // Check for duplicate role name (excluding current role)
        //    if (await _context.Roles.AnyAsync(r => r.Name == request.Name && r.Id != entity.Id))
        //    {
        //        throw new InvalidOperationException("A role with this name already exists.");
        //    }
        //}
    }
} 