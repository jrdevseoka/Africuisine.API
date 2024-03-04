using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public override HttpStatusCode Code => HttpStatusCode.BadRequest;
    }
}