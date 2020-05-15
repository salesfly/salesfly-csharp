namespace Salesfly.Exceptions
{
    public class APITimeoutException : APIException
    {
        public APITimeoutException(string message) : base(message)
        {
        }
    }
}