namespace RestaurantAPI.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string messagge) : base(messagge)
        {
            
        }
    }
}
