using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Municipalities.Common.Logging;
using MunicipalitiesApi.Attributes;
using MunicipalitiesApi.Infrastructure;

namespace MunicipalitiesApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Exception handling and logging
            GlobalConfiguration.Configuration.Filters.Add(new AnyExceptionFilterAttribute());
            config.Services.Add(typeof(IExceptionLogger), new TraceExceptionLogger(new DatabaseLogger()));
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }
    }
}