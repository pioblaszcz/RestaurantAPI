using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Authorization
{
    public class CreatedMultipleRestaurantRequirmentHandler : AuthorizationHandler<CreatedMultipleRestaurantRequirment>
    {
        private readonly RestaurantDbContext _context;
        public CreatedMultipleRestaurantRequirmentHandler(RestaurantDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleRestaurantRequirment requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var createdRestaurnantCount = _context
                .Restaurants
                .Count(r => r.CreatedById == userId);

            if(createdRestaurnantCount >= requirement.MinimumRestaurantCreated)context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
