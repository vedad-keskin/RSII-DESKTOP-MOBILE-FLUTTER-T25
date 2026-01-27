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
    public class UserActivityService : BaseCRUDService<UserActivityResponse, UserActivitySearchObject, Database.UserActivityIB180079, UserActivityUpsertRequest, UserActivityUpsertRequest>, IUserActivityService
    {
        public UserActivityService(eCommerceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override UserActivityResponse MapToResponse(Database.UserActivityIB180079 entity)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == entity.UserId);

            var activity = _context.ActivityIB180079.FirstOrDefault(x => x.Id == entity.ActivityId);

            var reward = _context.RewardRuleIB180079.FirstOrDefault(x => x.ActivityId == entity.ActivityId);    

            return new UserActivityResponse
            {
                UserFullName = $"{user.FirstName} {user.LastName}",
                Status = entity.Status,
                ActivityName = activity.Name,
                DueDate = activity.DueDate,
                NumberOfPoints = reward?.NumberOfPoints ?? 0, 

            };
        }

        public async Task<UserActivityResponse> ChangeStatusAsync(int id, string status)
        {

            var userActivity = await _context.UserActivityIB180079
                .Include(x => x.User)
                .Include(x => x.Activity)
                .FirstOrDefaultAsync(x => x.Id == id);

            var rewardRule = await _context.RewardRuleIB180079.FirstOrDefaultAsync(x => x.ActivityId == userActivity.ActivityId);

            if (userActivity == null)
            {

                throw new InvalidOperationException("UserActivity not found.");

            }

            string currentStatus = userActivity.Status;


            if (currentStatus == "Assigned" && (status == "InProgress" || status == "Cancelled"))
            {
                
                if(status == "InProgress" && DateTime.Now > userActivity.Activity.DueDate)
                {

                    throw new InvalidOperationException("Activity due date has passed.");

                }


                userActivity.Status = status;   

            }
            else if(currentStatus == "InProgress" && (status == "Completed" || status == "Cancelled"))
            {

                userActivity.Status = status;   

                if(status == "Completed")
                {

                    userActivity.CompletedAt = DateTime.Now;
                    userActivity.RewardedAt = DateTime.Now;
                    userActivity.RewardTitle = rewardRule.RewardTitle;

                }



            }
            else
            {

                throw new InvalidOperationException("Invalid status transition.");

            }

            await _context.SaveChangesAsync();

            return _mapper.Map<UserActivityResponse>(userActivity);

        }

        protected override IQueryable<Database.UserActivityIB180079> ApplyFilter(IQueryable<Database.UserActivityIB180079> query, UserActivitySearchObject search)
        {
            if (!string.IsNullOrEmpty(search.Status))
            {
                query = query.Where(r => r.Status.Contains(search.Status));
            }


            return query;
        }

        protected override async Task BeforeInsert(Database.UserActivityIB180079 entity, UserActivityUpsertRequest request)
        {

            entity.Status = "Assigned";
            entity.DateAssigned = DateTime.Now;

        }

 
    }
} 