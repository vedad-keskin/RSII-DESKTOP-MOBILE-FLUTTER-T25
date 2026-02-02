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
    public class ProductDiscountService : BaseCRUDService<ProductDiscountResponse, ProductDiscountSearchObject, ProductDiscount, ProductDiscountUpsertRequest, ProductDiscountUpsertRequest>, IProductDiscountService
    {
        public ProductDiscountService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<ProductDiscount> ApplyFilter(IQueryable<ProductDiscount> query, ProductDiscountSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.ProductName))
            {
                query = query.Where(pd => pd.Product.Name.Contains(search.ProductName));
            }

            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(pd => pd.Product.Name.Contains(search.FTS));
            }

            // Include Product and Assets for response mapping
            query = query.Include(x => x.Product.Assets);

            return query;
        }
   

        protected override async Task BeforeInsert(ProductDiscount entity, ProductDiscountUpsertRequest request)
        {
            await ValidateDiscountRequest(entity, request);
        }

        protected override async Task BeforeUpdate(ProductDiscount entity, ProductDiscountUpsertRequest request)
        {
            await ValidateDiscountRequest(entity, request, entity.Id);
        }

        private async Task ValidateDiscountRequest(ProductDiscount entity, ProductDiscountUpsertRequest request, int excludeId = -1)
        {
            // Validate DateFrom < DateTo
            if (request.DateFrom >= request.DateTo)
            {
                throw new InvalidOperationException("DateFrom must be less than DateTo.");
            }

            // Validate discount range (0-100%)
            if (request.Discount < 0 || request.Discount > 100)
            {
                throw new InvalidOperationException("Discount must be between 0 and 100 percent.");
            }


            // Check if any discount already exists in that period
            var overlappingDiscounts = await _context.ProductDiscounts
                .AnyAsync(x =>
                    x.ProductId == request.ProductId &&
                    x.Id != excludeId &&

                    (
                        // New start is within an existing range
                        (request.DateFrom >= x.DateFrom && request.DateFrom <= x.DateTo) ||

                        // New end is within an existing range
                        (request.DateTo >= x.DateFrom && request.DateTo <= x.DateTo) ||

                        // New range fully contains an existing range
                        (request.DateFrom <= x.DateFrom && request.DateTo >= x.DateTo)
                    )
                );


            if (overlappingDiscounts)
            {
                throw new InvalidOperationException("A product cannot have overlapping discounts. Please ensure the date ranges do not overlap with existing discounts.");
            }
        }

        protected override ProductDiscountResponse MapToResponse(ProductDiscount entity)
        {
            var response = new ProductDiscountResponse
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                ProductName = entity.Product?.Name ?? string.Empty,
                ProductPrice = entity.Product?.Price ?? 0,
                Discount = entity.Discount,
                DateFrom = entity.DateFrom,
                DateTo = entity.DateTo
            };

            // Calculate NewPrice (old price reduced by discount percentage)
            if (entity.Product != null)
            {
                response.NewPrice = entity.Product.Price * (1 - entity.Discount / 100);
            }

            // Map assets
            if (entity.Product?.Assets != null)
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

     

    
    }
}
