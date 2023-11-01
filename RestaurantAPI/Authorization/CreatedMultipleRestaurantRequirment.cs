using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class CreatedMultipleRestaurantRequirment : IAuthorizationRequirement
    {
        public CreatedMultipleRestaurantRequirment(int minimumRestaurantCreated)
        {
            MinimumRestaurantCreated = minimumRestaurantCreated;
        }

        public int MinimumRestaurantCreated { get;}
    }
}
