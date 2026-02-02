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
                
            };

            if(entity.Product != null)
            {

                response.NewPrice = entity.Product.Price * (1 - entity.Discount / 100);

            }


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



        protected override async Task BeforeInsert(Database.ProductDiscount entity, ProductDiscountUpsertRequest request)
        {

            await ValidateDiscountRequest(entity, request);

        }


        protected override async Task BeforeUpdate(Database.ProductDiscount entity, ProductDiscountUpsertRequest request)
        {

            await ValidateDiscountRequest(entity, request, entity.Id);

        }
        private async Task ValidateDiscountRequest(ProductDiscount entity, ProductDiscountUpsertRequest request, int excludeId = -1)
        {
            
            if(request.DateFrom >= request.DateTo)
            {

                throw new InvalidOperationException("Date From must be less than Date To.");

            }

            if(request.Discount < 0 || request.Discount > 100)
            {

                throw new InvalidOperationException("Discount must be between 0 and 100 percent.");


            }

            var overlappingDiscount = await _context.ProductDiscounts
                .AnyAsync(
                x => 
                x.ProductId == request.ProductId
                && 
                x.Id != excludeId

                &&
                (
                (request.DateFrom >= x.DateFrom && request.DateFrom <= x.DateTo)
                ||
                (request.DateTo >= x.DateFrom && request.DateTo <= x.DateTo)
                ||
                (request.DateFrom <= x.DateFrom && request.DateTo >= x.DateTo)
                )
                );

            if (overlappingDiscount)
            {

                throw new InvalidOperationException("A Product cannot have overlapping discounts. Please ensure the date ranges do not overlap.");


            }


        }
    }
} 