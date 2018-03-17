using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MunicipalitiesApi.Attributes
{
    /// <summary>
    /// Customizes response with exception message when server exception occurs
    /// Not all exceptions are caught here, see
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/web-api-global-error-handling
    /// </summary>
    public class AnyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            actionExecutedContext.Response.Content = new StringContent(actionExecutedContext.Exception.Message);
        }
    }
}