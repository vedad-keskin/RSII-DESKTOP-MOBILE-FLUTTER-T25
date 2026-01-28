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
    public class ActivityService : BaseCRUDService<ActivityResponse, ActivitySearchObject, Database.ActivityIB180079, ActivityUpsertRequest, ActivityUpsertRequest>, IActivityService
    {
        public ActivityService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Database.ActivityIB180079> ApplyFilter(IQueryable<Database.ActivityIB180079> query, ActivitySearchObject search)
        {
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(r => r.Name.Contains(search.Name));
            }

            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(r => r.Name.Contains(search.FTS) || r.Description.Contains(search.FTS));
            }


            return query;
        }

        protected override async Task BeforeInsert(Database.ActivityIB180079 entity, ActivityUpsertRequest request)
        {
            // Check for duplicate role name
            if (await _context.ActivityIB180079.AnyAsync(r => r.Name == request.Name))
            {
                throw new InvalidOperationException("An acivitiy with that name already exists.");
            }
        }

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