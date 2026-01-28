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
    public class RewardRuleService : BaseCRUDService<RewardRuleResponse, RewardRuleSearchObject, Database.RewardRuleIB180079, RewardRuleUpsertRequest, RewardRuleUpsertRequest>, IRewardRuleService
    {
        public RewardRuleService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<Database.RewardRuleIB180079> ApplyFilter(IQueryable<Database.RewardRuleIB180079> query, RewardRuleSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.RewardTitle))
            {
                query = query.Where(r => r.RewardTitle.Contains(search.RewardTitle));
            }

            if (!string.IsNullOrEmpty(search.FTS))
            {
                query = query.Where(r => r.RewardTitle.Contains(search.FTS));
            }


            return query;
        }

        protected override async Task BeforeInsert(Database.RewardRuleIB180079 entity, RewardRuleUpsertRequest request)
        {
            // Check for duplicate role name
            if (await _context.RewardRuleIB180079.AnyAsync(r => r.ActivityId == request.ActivityId))
            {
                throw new InvalidOperationException("A reward for that activity already exists.");
            }

            var activity = _context.ActivityIB180079.FirstOrDefault(x => x.Id == request.ActivityId);

            entity.RewardTitle = $"{activity.Name} - {request.NumberOfPoints} points";

            entity.MaxDaysToComplete = (int)(activity.DueDate.Date - DateTime.Now).TotalDays;


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