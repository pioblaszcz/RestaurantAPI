using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement)
        {
            var value = context.User.FindFirst(c => c.Type == "DateOfBirth")?.Value;
            if (value != null)
            {
                var dateOfBirth =  DateTime.Parse(value);
                if (dateOfBirth.AddYears(requirement.MinimumAge) < DateTime.Today)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
